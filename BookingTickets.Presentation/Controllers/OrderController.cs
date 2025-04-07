using BookingTickets.Business.Services;
using BookingTickets.Core.Entities;
using BookingTickets.Core.Enums;
using BookingTickets.Core.ViewModels;
using BookingTickets.DataAccess.Data.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe;

namespace BookingTickets.Presentation.Controllers
{
    public class OrderController (BookingTicketsDbContext dbContext,UserManager<AppUser> userManager, QrCodeService qrCodeService) : Controller
    {

        [Authorize(Roles = "Member")]
        public IActionResult CheckOut()
        {
            var user = userManager.Users
                .Include(u => u.BasketItems)
                    .ThenInclude(b => b.Ticket)
                        .ThenInclude(t => t.Event)
                .FirstOrDefault(u => u.UserName == User.Identity.Name);

            if (user == null) return RedirectToAction("Login", "Account");

            var vm = new CheckOutVm
            {
                CheckoutItemVms = user.BasketItems.Select(b => new CheckoutItemVm
                {
                    EventName = b.Ticket.Event.Name,
                    TotalItemPrice = b.Ticket.Price
                }).ToList(),
                OrderVm = new OrderVm()
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Member")]
        public IActionResult CheckOut(OrderVm orderVm, string stripeEmail, string stripeToken)
        {
            var user = userManager.Users
                .Include(u => u.BasketItems)
                    .ThenInclude(b => b.Ticket)
                .FirstOrDefault(u => u.UserName == User.Identity.Name);

            if (user == null) return RedirectToAction("Login", "Account");

            if (!ModelState.IsValid)
            {
                var vm = new CheckOutVm
                {
                    CheckoutItemVms = user.BasketItems.Select(b => new CheckoutItemVm
                    {
                        EventName = b.Ticket.Event.Name,
                        TotalItemPrice = b.Ticket.Price
                    }).ToList(),
                    OrderVm = orderVm
                };

                return View(vm);
            }

            var total = user.BasketItems.Sum(b => b.Ticket.Price);

            #region Stripe Integration
            var customerService = new CustomerService();
            var customer = customerService.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Name = user.FullName,
                Phone = orderVm.PhoneNumber,
            });

            var chargeService = new ChargeService();
            var charge = chargeService.Create(new ChargeCreateOptions
            {
                Amount = (long)(total * 100),
                Currency = "usd",
                Description = "Ticket order",
                Source = stripeToken,
                ReceiptEmail = stripeEmail
            });

            if (charge.Status != "succeeded")
            {
                ModelState.AddModelError("", "Ödəniş alınmadı. Yenidən cəhd edin.");
                return View();
            }
            #endregion

            // Create Order
            var order = new Order
            {
                AppUserId = user.Id,
                PhoneNumber = orderVm.PhoneNumber,
                OrderStatus = OrderStatus.Completed,
                OrderItems = new List<OrderItem>()
            };

            foreach (var item in user.BasketItems)
            {
                var ticket = item.Ticket;

                ticket.AppUserId = user.Id;
                ticket.Status = TicketStatus.Purchased;
                ticket.PurchaseDate = DateTime.Now;
                ticket.ValidationToken = Guid.NewGuid().ToString();
                ticket.QRCodePath = qrCodeService.GenerateTicketPDF(ticket);

                order.OrderItems.Add(new OrderItem
                {
                    TicketId = ticket.Id
                });
            }

            dbContext.Orders.Add(order);

            dbContext.BasketItems.RemoveRange(user.BasketItems);
            dbContext.SaveChanges();

            return RedirectToAction("Success");
        }





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
        [Authorize(Roles = "Member")]
        public IActionResult Cancel(int orderId)
        {
            var order=dbContext.Orders
                .Where(o => o.AppUserId == userManager.GetUserId(User))
                .FirstOrDefault(o => o.Id == orderId);
            order.OrderStatus = OrderStatus.Cancelled;
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Basket");
        }
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
    }
}
