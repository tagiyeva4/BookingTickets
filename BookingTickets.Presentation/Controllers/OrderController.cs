using BookingTickets.Core.Entities;
using BookingTickets.Core.Enums;
using BookingTickets.Core.ViewModels;
using BookingTickets.DataAccess.Data.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.Presentation.Controllers
{
    public class OrderController (BookingTicketsDbContext dbContext,UserManager<AppUser> userManager): Controller
    {
        [Authorize(Roles = "Member")]
        public IActionResult CheckOut()
        {
            var user =userManager.Users
                .Include(u=>u.BasketItems)
                .ThenInclude(b => b.Ticket)
                .FirstOrDefault(u => u.UserName == User.Identity.Name);

            CheckOutVm checkOutVm = new CheckOutVm();

            checkOutVm.CheckoutItemVms = user.BasketItems.Select(b => new CheckoutItemVm
            {
                EventName = b.Ticket.Event.Name,
                TotalItemPrice = b.Ticket.Event.MinPrice
            }).ToList();

            return View(checkOutVm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Member")]
        public IActionResult CheckOut(OrderVm orderVm)
        {
            var user=userManager.Users
                .Include(u => u.BasketItems)
                .ThenInclude(b => b.Ticket)
                .FirstOrDefault(u => u.UserName == User.Identity.Name);

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if(!ModelState.IsValid)
            {
                CheckOutVm checkOutVm = new CheckOutVm();
                checkOutVm.CheckoutItemVms = user.BasketItems.Select(b => new CheckoutItemVm
                {
                    EventName = b.Ticket.Event.Name,
                    TotalItemPrice = b.Ticket.Event.MinPrice
                }).ToList();

                checkOutVm.OrderVm = orderVm;

               return View(checkOutVm);
            }

            Order order = new Order();

            order.AppUserId = user.Id;

            order.PhoneNumber = orderVm.PhoneNumber;

            order.OrderStatus = OrderStatus.Pending;

            order.OrderItems = user.BasketItems.Select(b => new OrderItem
            {
                TicketId = b.TicketId,
            }).ToList();

            dbContext.Orders.Add(order);

            dbContext.BasketItems.RemoveRange(user.BasketItems);

            dbContext.SaveChanges();

            HttpContext.Response.Cookies.Delete("basket");

            return RedirectToAction("Index", "Basket");

        }
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
