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
                TotalItemPrice = b.Ticket.Event.MinPrice,
                Count=b.Count
            }).ToList();

            return View(checkOutVm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "member")]
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
                    TotalItemPrice = b.Ticket.Event.MinPrice,
                    Count = b.Count
                }).ToList();
                checkOutVm.OrderVm = orderVm;
               return View(checkOutVm);
            }
            Order order = new Order();
            order.AppUserId = user.Id;
            order.PhoneNumber = orderVm.PhoneNumber;
            order.OrderStatus = OrderStatus.Pending;
            order.TotalPrice =user.BasketItems.Sum(c => c.Ticket.Event.MaxPrice * c.Count);
            order.OrderItems = user.BasketItems.Select(b => new OrderItem
            {
                TicketId = b.TicketId,
                Count = b.Count
            }).ToList();
            dbContext.Orders.Add(order);
            dbContext.BasketItems.RemoveRange(user.BasketItems);
            dbContext.SaveChanges();
            HttpContext.Response.Cookies.Delete("basket");
            return RedirectToAction("Index", "Basket");

        }
    }
}
