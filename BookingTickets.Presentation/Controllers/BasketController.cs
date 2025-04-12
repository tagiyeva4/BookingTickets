using BookingTickets.Core.Entities;
using BookingTickets.Core.Enums;
using BookingTickets.Core.ViewModels;
using BookingTickets.DataAccess.Data.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BookingTickets.Presentation.Controllers
{
    public class BasketController(BookingTicketsDbContext dbContext,UserManager<AppUser> userManager) : Controller
    {
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var basketTickets = dbContext.Tickets
                .Include(x => x.Event)
                .Include(x => x.VenueSeat)
                .Where(x => x.AppUserId == userId && x.Status == TicketStatus.Reserved)
                .ToList();

            // Vaxtı keçmiş biletləri sil
            var now = DateTime.Now;
            var expiredTickets = basketTickets.Where(t => t.ExpiresAt <= now).ToList();

            if (expiredTickets.Any())
            {
                dbContext.Tickets.RemoveRange(expiredTickets);
                dbContext.SaveChanges();
                basketTickets = basketTickets.Except(expiredTickets).ToList();
            }

            var basketItems = basketTickets.Select(t => new BasketItemVm
            {
                Id = t.Id,
                Name = t.Event.Name,
                EventName = t.Event.Name,
                Price = t.Price,
                Count = 1,
                ExpireAt = t.ExpiresAt,
                SeatLocation ="Seat Number" + " " + t.VenueSeat.SeatNumber+" "+"Row Name" + " " + t.VenueSeat.RowName,
            }).ToList();

            return View(basketItems);
        
            //var basket = HttpContext.Request.Cookies["basket"];
            //List<BasketItemVm> basketItemVms ;
            //if (basket != null)
            //{
            //    basketItemVms = Newtonsoft.Json.JsonConvert.DeserializeObject<List<BasketItemVm>>(basket);
            //}
            //else
            //{
            //    basketItemVms = new List<BasketItemVm>();
            //}
            //ViewBag.Tickets= dbContext.Tickets.Include(x => x.Event).ToList();
            //return View(basketItemVms);
        }
        [HttpGet]
        public IActionResult ReserveTicket() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ReserveTicket(int eventId, int seatId)
        {
            var seat = dbContext.VenueSeats.FirstOrDefault(s => s.Id == seatId);
            if (seat == null)
            {
                TempData["Error"] = "Yer tapılmadı.";
                return RedirectToAction("Detail", "Event", new { id = eventId });
            }

            var @event = dbContext.Events
                .Include(e => e.Tickets)
                .Include(e => e.Venue)
                .ThenInclude(v => v.Seats)
                .FirstOrDefault(e => e.Id == eventId);

            if (@event == null)
            {
                TempData["Error"] = "Tədbir tapılmadı.";
                return RedirectToAction("Index", "Event");
            }

            var isTaken = dbContext.Tickets.Any(t =>
                t.VenueSeatId == seatId &&
                (t.Status == TicketStatus.Purchased || (t.Status == TicketStatus.Reserved && t.ExpiresAt > DateTime.Now)));

            if (isTaken)
            {
                TempData["Error"] = "Bu yer artıq tutulub.";
                return RedirectToAction("Detail", "Event", new { id = eventId });
            }

            var ticket = new Ticket
            {
                EventId = eventId,
                VenueSeatId = seatId,
                Status = TicketStatus.Reserved,
                Price = seat.Price,
                ReservedAt = DateTime.Now,
                ExpiresAt = DateTime.Now.AddMinutes(15),
                ValidationToken = Guid.NewGuid().ToString(),
                AppUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
            };

            dbContext.Tickets.Add(ticket);
            dbContext.SaveChanges();

            TempData["Success"] = "Ticket added to basket.";
          return RedirectToAction("Detail", "Event", new { id = eventId });
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var ticket = dbContext.Tickets.FirstOrDefault(t => t.Id == id && t.AppUserId == userId && t.Status == TicketStatus.Reserved);

            if (ticket == null)
            {
                return NotFound();
            }

            dbContext.Tickets.Remove(ticket);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}
