using BookingTickets.Business.Dtos;
using BookingTickets.Business.Services;
using BookingTickets.Business.Services.Abstractions;
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

    public class OrderController(BookingTicketsDbContext dbContext, UserManager<AppUser> userManager, QrCodeService qrCodeService, IPaymentService _paymentService) : Controller
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
            Response.Cookies.Append("basket", json, new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddMinutes(39)
            });

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
            //var domain = "https://localhost:7230";

            //var options = new SessionCreateOptions
            //{
            //    PaymentMethodTypes = new List<string> { "card" },
            //    LineItems = reservedTickets.Select(t => new SessionLineItemOptions
            //    {
            //        PriceData = new SessionLineItemPriceDataOptions
            //        {
            //            UnitAmount = (long)(t.Price * 100),
            //            Currency = "azn",
            //            ProductData = new SessionLineItemPriceDataProductDataOptions
            //            {
            //                Name = t.Event.Name
            //            }
            //        },
            //        Quantity = 1
            //    }).ToList(),
            //    Mode = "payment",
            //    SuccessUrl = $"{domain}/Order/PaymentSuccess?orderId={order.Id}",
            //    CancelUrl = $"{domain}/Order/Checkout"
            //};

            //var service = new SessionService();
            //var session = await service.CreateAsync(options);

            //order.StripeSessionId = session.Id;
            //order.StripePaymentIntentId = session.PaymentIntentId;
            //await dbContext.SaveChangesAsync();

            var response = await _paymentService.CreateAsync(new PaymentCreateDto
            {
                Amount = reservedTickets.Sum(t => t.Price),
                Description = "Order payment",
                OrderId = order.Id
            });


            

            string paymentUrl = $"{response.Order.HppUrl}?id={response.Order.Id}&password={response.Order.Password}";

            return Redirect(paymentUrl);
        }


        //public async Task<IActionResult> PaymentSuccess(int orderId, [FromServices] IPdfService pdfService)
        //{
        //    var order = await dbContext.Orders
        //        .Include(o => o.OrderItems)
        //            .ThenInclude(oi => oi.Ticket)
        //                .ThenInclude(t => t.Event)
        //        .Include(o => o.OrderItems)
        //            .ThenInclude(oi => oi.Ticket.VenueSeat)
        //        .FirstOrDefaultAsync(o => o.Id == orderId);

        //    if (order == null)
        //    {
        //        TempData["Error"] = "Order not found.";
        //        return RedirectToAction("Index", "Home");
        //    }

        //    order.OrderStatus = OrderStatus.Completed;
        //    order.PaidAt = DateTime.Now;

        //    foreach (var item in order.OrderItems)
        //    {
        //        var ticket = item.Ticket;
        //        ticket.Status = TicketStatus.Purchased;
        //        ticket.PurchaseDate = DateTime.Now;

        //        // QR Code yaradılıbsa saxlanılıb
        //        var vm = new MyTicketVm
        //        {
        //            TicketId = ticket.Id,
        //            EventName = ticket.Event.Name,
        //            SeatNumber = ticket.VenueSeat.SeatNumber,
        //            SeatLocation = ticket.VenueSeat.Location,
        //            Price = ticket.Price,
        //            PurchaseDate = ticket.PurchaseDate ?? DateTime.Now,
        //            QRCodePath = ticket.QRCodePath
        //        };

        //        var pdfBytes = pdfService.GenerateTicketPdf(vm);

        //        var pdfPath = Path.Combine("wwwroot", "tickets", $"ticket_{ticket.Id}.pdf");
        //        System.IO.File.WriteAllBytes(pdfPath, pdfBytes);

        //        // Optional: Biletə PDF yolunu əlavə edə bilərsən
        //        // ticket.PdfPath = "/tickets/ticket_123.pdf";
        //    }

        //    await dbContext.SaveChangesAsync();

        //    TempData["Success"] = "Payment completed successfully!";
        //    return RedirectToAction("MyTickets", "Ticket");
        //}



        //public async Task<IActionResult> PaymentSuccess(int orderId)
        //{
        //    var order = await dbContext.Orders
        //        .Include(o => o.OrderItems)
        //            .ThenInclude(oi => oi.Ticket)
        //        .FirstOrDefaultAsync(o => o.Id == orderId);

        //    if (order == null)
        //    {
        //        TempData["Error"] = "Order not found.";
        //        return RedirectToAction("Index", "Home");
        //    }

        //    order.OrderStatus = OrderStatus.Completed;
        //    order.PaidAt = DateTime.Now;

        //    foreach (var item in order.OrderItems)
        //    {
        //        item.Ticket.Status = TicketStatus.Purchased;
        //        item.Ticket.PurchaseDate = DateTime.Now;
        //    }

        //    await dbContext.SaveChangesAsync();

        //    TempData["Success"] = "Payment completed successfully!";
        //    return RedirectToAction("Index", "Home");
        //}



        public async Task<IActionResult> CheckPayment(PaymentCheckDto dto)
        {
            var result = await _paymentService.CheckPaymentAsync(dto);

            return RedirectToAction("Index", "Event");
        }
    }
}
















