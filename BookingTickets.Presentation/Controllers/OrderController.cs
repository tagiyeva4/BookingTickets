using BookingTickets.Business.Services;
using BookingTickets.Core.Entities;
using BookingTickets.Core.Enums;
using BookingTickets.Core.ViewModels;
using BookingTickets.DataAccess.Data.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Stripe;
using Stripe.Checkout;
using System.Security.Claims;

namespace BookingTickets.Presentation.Controllers
{
    
    public class OrderController(BookingTicketsDbContext dbContext, UserManager<AppUser> userManager, QrCodeService qrCodeService) : Controller
    {
        /// <summary>
        /// Session-a bilet ID-lərini yazır
        /// </summary>
        /// <param name="selectedTicketIds"></param>
        /// <returns></returns>
        public IActionResult AddToCart(List<int> selectedTicketIds)
        {
            var json = JsonConvert.SerializeObject(selectedTicketIds);
            HttpContext.Session.SetString("SelectedTicketIds", json);

            return RedirectToAction("Checkout");
        }
        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var reservedTickets = await dbContext.Tickets
                .Include(t => t.Event)
                .Where(t => t.AppUserId == userId &&
                            t.Status == TicketStatus.Reserved &&
                            t.ExpiresAt > DateTime.Now)
                .ToListAsync();

            if (!reservedTickets.Any())
            {
                TempData["Error"] = "No reserved tickets found.";
                return RedirectToAction("Index", "Event");
            }

            var vm = new CheckOutVm
            {
                CheckoutItemVms = reservedTickets.Select(t => new CheckoutItemVm
                {
                    TicketId = t.Id,
                    EventName = t.Event.Name,
                    TotalItemPrice = t.Price
                }).ToList(),
                OrderVm = new OrderVm()
            };

            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCheckoutSession(CheckOutVm model)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var reservedTickets = await dbContext.Tickets
                .Include(t => t.Event)
                .Where(t => t.AppUserId == userId &&
                            t.Status == TicketStatus.Reserved &&
                            t.ExpiresAt > DateTime.Now)
                .ToListAsync();

            if (!reservedTickets.Any())
            {
                TempData["Error"] = "Your basket is empty or expired.";
                return RedirectToAction("Index", "Event");
            }

            var order = new Order
            {
                PhoneNumber = model.OrderVm.PhoneNumber,
                PromoCode = model.OrderVm.PromoCode,
                OrderStatus = OrderStatus.Pending,
                AppUserId = userId,
                CreatedDate = DateTime.Now,
                OrderItems = reservedTickets.Select(t => new OrderItem
                {
                    TicketId = t.Id,
                    UnitPrice = t.Price,
                    Count = 1
                }).ToList()
            };

            dbContext.Orders.Add(order);
            await dbContext.SaveChangesAsync();

            // Stripe session
            var domain = "https://localhost:7230";

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = reservedTickets.Select(t => new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(t.Price * 100),
                        Currency = "azn",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = t.Event.Name
                        }
                    },
                    Quantity = 1
                }).ToList(),
                Mode = "payment",
                SuccessUrl = $"{domain}/Order/PaymentSuccess?orderId={order.Id}",
                CancelUrl = $"{domain}/Order/Checkout"
            };

            var service = new SessionService();
            var session = await service.CreateAsync(options);

            order.StripeSessionId = session.Id;
            order.StripePaymentIntentId = session.PaymentIntentId;
            await dbContext.SaveChangesAsync();

            return Redirect(session.Url);
        }


        public async Task<IActionResult> PaymentSuccess(int orderId)
        {
            var order = await dbContext.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Ticket)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
            {
                TempData["Error"] = "Order not found.";
                return RedirectToAction("Index", "Home");
            }

            order.OrderStatus = OrderStatus.Completed;
            order.PaidAt = DateTime.Now;

            foreach (var item in order.OrderItems)
            {
                item.Ticket.Status = TicketStatus.Purchased;
                item.Ticket.PurchaseDate = DateTime.Now;
            }

            await dbContext.SaveChangesAsync();

            TempData["Success"] = "Payment completed successfully!";
            return RedirectToAction("MyTickets");
        }























        //[Authorize(Roles = "Member")]
        //public IActionResult Checkout()

        //{

        //    var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        //    var tickets = dbContext.Tickets
        //        .Include(t => t.Event)
        //        .Include(t => t.VenueSeat)
        //        .Where(t => t.AppUserId == userId && t.Status == TicketStatus.Reserved && t.ExpiresAt > DateTime.Now)
        //        .ToList();

        //    var vm = new CheckOutVm
        //    {
        //        CheckoutItemVms = tickets.Select(t => new CheckoutItemVm
        //        {
        //            EventName = t.Event.Name,
        //            TotalItemPrice = t.Price
        //        }).ToList(),
        //        OrderVm = new OrderVm()
        //    };

        //    return View(vm);
        //}



        //[ValidateAntiForgeryToken]
        //[Authorize(Roles = "Member")]
        //[HttpPost]
        //public async Task<IActionResult> Checkout(CheckOutVm vm)
        //{
        //    if (!ModelState.IsValid)
        //        return View(vm);

        //    var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        //    var reservedTickets = dbContext.Tickets
        //        .Include(t => t.Event)
        //        .Include(t => t.VenueSeat)
        //        .Where(t => t.AppUserId == userId && t.Status == TicketStatus.Reserved && t.ExpiresAt > DateTime.Now)
        //        .ToList();

        //    var totalPrice = reservedTickets.Sum(t => t.Price);

        //    var order = new Order
        //    {
        //        AppUserId = userId,
        //        PhoneNumber = vm.OrderVm.PhoneNumber,
        //        PromoCode = vm.OrderVm.PromoCode,
        //        TotalPrice = totalPrice,
        //        OrderStatus = OrderStatus.Pending
        //    };

        //    dbContext.Orders.Add(order);
        //    await dbContext.SaveChangesAsync();

        //    foreach (var ticket in reservedTickets)
        //    {
        //        var orderItem = new OrderItem
        //        {
        //            TicketId = ticket.Id,
        //            Count = 1,
        //            OrderId = order.Id,
        //            UnitPrice = ticket.Price,
        //            SeatDescription = $"Row {ticket.VenueSeat.RowName}, Seat {ticket.VenueSeat.SeatLabel}"
        //        };

        //        dbContext.OrderItems.Add(orderItem);
        //        ticket.OrderId = order.Id;
        //    }

        //    await dbContext.SaveChangesAsync();

        //    return RedirectToAction("CreateCheckoutSession", new { orderId = order.Id });
        //}


        //[HttpGet]
        //public async Task<IActionResult> CreateCheckoutSession(int orderId)
        //{
        //    var order = await dbContext.Orders
        //        .Include(o => o.OrderItems)
        //            .ThenInclude(oi => oi.Ticket)
        //                .ThenInclude(t => t.Event)
        //        .FirstOrDefaultAsync(o => o.Id == orderId);

        //    if (order == null)
        //    {
        //        TempData["Error"] = "Sifariş tapılmadı.";
        //        return RedirectToAction("Checkout");
        //    }

        //    var domain = "https://localhost:7230";

        //    var options = new SessionCreateOptions
        //    {
        //        PaymentMethodTypes = new List<string> { "card" },
        //        LineItems = order.OrderItems.Select(item => new SessionLineItemOptions
        //        {
        //            PriceData = new SessionLineItemPriceDataOptions
        //            {
        //                UnitAmount = (long)(item.UnitPrice * 100),
        //                Currency = "azn",
        //                ProductData = new SessionLineItemPriceDataProductDataOptions
        //                {
        //                    Name = item.Ticket.Event.Name
        //                }
        //            },
        //            Quantity = item.Count
        //        }).ToList(),
        //        Mode = "payment",
        //        SuccessUrl = $"{domain}/Order/PaymentSuccess?orderId={order.Id}",
        //        CancelUrl = $"{domain}/Order/Checkout"
        //    };

        //    var service = new SessionService();
        //    var session = await service.CreateAsync(options);

        //    order.StripeSessionId = session.Id;
        //    order.StripePaymentIntentId = session.PaymentIntentId;
        //    await dbContext.SaveChangesAsync();

        //    return Redirect(session.Url);
        //}

        //public async Task<IActionResult> PaymentSuccess(int orderId, string paymentIntentId)
        //{
        //    var order = await dbContext.Orders
        //        .Include(o => o.OrderItems)
        //            .ThenInclude(oi => oi.Ticket)
        //        .FirstOrDefaultAsync(o => o.Id == orderId);

        //    if (order == null)
        //    {
        //        TempData["Error"] = "Sifariş tapılmadı.";
        //        return RedirectToAction("Index", "Home");
        //    }

        //    order.OrderStatus = OrderStatus.Completed;
        //    order.PaidAt = DateTime.Now;
        //    order.StripePaymentIntentId = paymentIntentId;

        //    foreach (var item in order.OrderItems)
        //    {
        //        item.Ticket.Status = TicketStatus.Purchased;
        //        item.Ticket.PurchaseDate = DateTime.Now;
        //    }

        //    await dbContext.SaveChangesAsync();

        //    TempData["Success"] = "Ödəniş uğurla tamamlandı!";
        //    return RedirectToAction("MyTickets");
        //}
    }
}



        //public IActionResult CheckOut(OrderVm orderVm, string stripeEmail, string stripeToken)
        //{
        //    var user = userManager.Users
        //        .Include(u => u.BasketItems)
        //            .ThenInclude(b => b.Ticket)
        //        .FirstOrDefault(u => u.UserName == User.Identity.Name);

        //    if (user == null) return RedirectToAction("Login", "Account");

        //    if (!ModelState.IsValid)
        //    {
        //        var vm = new CheckOutVm
        //        {
        //            CheckoutItemVms = user.BasketItems.Select(b => new CheckoutItemVm
        //            {
        //                EventName = b.Ticket.Event.Name,
        //                TotalItemPrice = b.Ticket.Price
        //            }).ToList(),
        //            OrderVm = orderVm
        //        };

        //        return View(vm);
        //    }

        //    var total = user.BasketItems.Sum(b => b.Ticket.Price);

        //    #region Stripe Integration
        //    var customerService = new CustomerService();
        //    var customer = customerService.Create(new CustomerCreateOptions
        //    {
        //        Email = stripeEmail,
        //        Name = user.FullName,
        //        Phone = orderVm.PhoneNumber,
        //    });

        //    var chargeService = new ChargeService();
        //    var charge = chargeService.Create(new ChargeCreateOptions
        //    {
        //        Amount = (long)(total * 100),
        //        Currency = "usd",
        //        Description = "Ticket order",
        //        Source = stripeToken,
        //        ReceiptEmail = stripeEmail
        //    });

        //    if (charge.Status != "succeeded")
        //    {
        //        ModelState.AddModelError("", "Ödəniş alınmadı. Yenidən cəhd edin.");
        //        return View();
        //    }
        //    #endregion

        //    // Create Order
        //    var order = new Order
        //    {
        //        AppUserId = user.Id,
        //        PhoneNumber = orderVm.PhoneNumber,
        //        OrderStatus = OrderStatus.Completed,
        //        OrderItems = new List<OrderItem>()
        //    };

        //    foreach (var item in user.BasketItems)
        //    {
        //        var ticket = item.Ticket;

        //        ticket.AppUserId = user.Id;
        //        ticket.Status = TicketStatus.Purchased;
        //        ticket.PurchaseDate = DateTime.Now;
        //        ticket.ValidationToken = Guid.NewGuid().ToString();
        //        ticket.QRCodePath = qrCodeService.GenerateTicketPDF(ticket);

        //        order.OrderItems.Add(new OrderItem
        //        {
        //            TicketId = ticket.Id
        //        });
        //    }

        //    dbContext.Orders.Add(order);

        //    dbContext.BasketItems.RemoveRange(user.BasketItems);
        //    dbContext.SaveChanges();

        //    return RedirectToAction("Success");
        //}





        //[Authorize(Roles = "Member")]
        //public IActionResult CheckOut()
        //{
        //    var user =userManager.Users
        //        .Include(u=>u.BasketItems)
        //        .ThenInclude(b => b.Ticket)
        //        .FirstOrDefault(u => u.UserName == User.Identity.Name);

        //    CheckOutVm checkOutVm = new CheckOutVm();

        //    checkOutVm.CheckoutItemVms = user.BasketItems.Select(b => new CheckoutItemVm
        //    {
        //        EventName = b.Ticket.Event.Name,
        //        TotalItemPrice = b.Ticket.Event.MinPrice
        //    }).ToList();

        //    return View(checkOutVm);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize(Roles = "Member")]
        //public IActionResult CheckOut(OrderVm orderVm,string stripeEmail,string stripeToken)
        //{
        //    var user=userManager.Users
        //        .Include(u => u.BasketItems)
        //        .ThenInclude(b => b.Ticket)
        //        .FirstOrDefault(u => u.UserName == User.Identity.Name);

        //    if (user == null)
        //    {
        //        return RedirectToAction("Login", "Account");
        //    }

        //    if(!ModelState.IsValid)
        //    {
        //        CheckOutVm checkOutVm = new CheckOutVm();
        //        checkOutVm.CheckoutItemVms = user.BasketItems.Select(b => new CheckoutItemVm
        //        {
        //            EventName = b.Ticket.Event.Name,
        //            TotalItemPrice = b.Ticket.Event.MinPrice
        //        }).ToList();

        //        checkOutVm.OrderVm = orderVm;

        //       return View(checkOutVm);
        //    }

        //    Order order = new Order();

        //    order.AppUserId = user.Id;

        //    order.PhoneNumber = orderVm.PhoneNumber;

        //    order.OrderStatus = OrderStatus.Pending;

        //    order.OrderItems = user.BasketItems.Select(b => new OrderItem
        //    {
        //        TicketId = b.TicketId,
        //    }).ToList();

        //    #region Stripe integration

        //    //var optionCust = new CustomerCreateOptions
        //    //{
        //    //    Email = stripeEmail,
        //    //    Name = user.FullName,
        //    //    Phone = orderVm.PhoneNumber,
        //    //};

        //    //var serviceCust = new CustomerService();

        //    //Customer customer = serviceCust.Create(optionCust);

        //    ////total=total*100;  (user.BasketItems.Sum(b => b.Ticket.Event.MinPrice) * 100)==total olacaq
        //    //var optionsCharge = new ChargeCreateOptions
        //    //{
        //    //    Amount = (long)(user.BasketItems.Sum(b => b.Ticket.Event.MinPrice) * 100),
        //    //    Currency = "USD",
        //    //    Description = "Ticket selling amount",
        //    //    Source = stripeToken,
        //    //    ReceiptEmail = stripeEmail
        //    //};

        //    //var serviceCharge = new ChargeService();

        //    //Charge charge = serviceCharge.Create(optionsCharge);

        //    //if (charge.Status != "succeeded")
        //    //{
        //    //    ViewBag.BasketItems = user.BasketItems;
        //    //    ModelState.AddModelError("PhoneNumber","Problem...");
        //    //    return View();
        //    //}
        //    #endregion


        //    dbContext.Orders.Add(order);

        //    dbContext.BasketItems.RemoveRange(user.BasketItems);

        //    dbContext.SaveChanges();

        //    HttpContext.Response.Cookies.Delete("basket");

        //    return RedirectToAction("Index", "Basket");

        //}
        //[Authorize(Roles = "Member")]
        //public IActionResult Cancel(int orderId)
        //{
        //    var order=dbContext.Orders
        //        .Where(o => o.AppUserId == userManager.GetUserId(User))
        //        .FirstOrDefault(o => o.Id == orderId);
        //    order.OrderStatus = OrderStatus.Cancelled;
        //    dbContext.SaveChanges();
        //    return RedirectToAction("Index", "Basket");
        //}
        //[Authorize(Roles = "Member")]
        //public IActionResult GetOrderItems(int orderId)
        //{
        //    var order = dbContext.Orders
        //        .Where(o => o.AppUserId == userManager.GetUserId(User))
        //        .Include(o => o.OrderItems)
        //        .ThenInclude(oi => oi.Ticket)
        //        .ThenInclude(t => t.Event)
        //        .FirstOrDefault(o => o.Id == orderId);

        //    return PartialView("_OrderItemsPartial", order);

        //}
    
