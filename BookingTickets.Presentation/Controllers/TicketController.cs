using BookingTickets.Business.Services;
using BookingTickets.Core.Entities;
using BookingTickets.DataAccess.Data.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.Presentation.Controllers
{
    public class TicketController(BookingTicketsDbContext dbContext) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult BuyTicket(int eventId)
        //{
        //    var userId = GetCurrentUserId();

        //    var ticket = new Ticket
        //    {
        //        EventId = eventId,
        //       AppUserId = userId,
        //        PurchaseDate = DateTime.Now,
        //        Status = 0,
        //        ValidationToken = Guid.NewGuid().ToString() // 🔐 Unikal token yaradılır
        //    };

        //    dbContext.Tickets.Add(ticket);
        //    dbContext.SaveChanges();

        //    var qrService = new QRCodeService();
        //    ticket.QRCodePath = qrService.GenerateQRCode(ticket.Id);
        //    dbContext.SaveChanges();

        //    return RedirectToAction("TicketDetails", new { id = ticket.Id });
        //}


        //public IActionResult ValidateTicket(string token)
        //{
        //    var ticket = dbContext.Tickets.FirstOrDefault(t => t.ValidationToken == token);

        //    if (ticket == null)
        //        return NotFound("Bilet tapılmadı və ya artıq istifadə olunub!");

        //    if (ticket.Status == "Validated")
        //        return Content("Bu bilet artıq təsdiqlənib!");

        //    ticket.Status = "Validated";
        //    dbContext.SaveChanges();

        //    return Content("Bilet uğurla təsdiqləndi!");
        //}

//        if (ticket.PurchaseDate.AddHours(24) < DateTime.Now)
//{
//    return Content("Bu biletin istifadə müddəti bitib!");
//    }

    }
}
