using BookingTickets.Business.Services;
using BookingTickets.Core.Entities;
using BookingTickets.Core.Enums;
using BookingTickets.Core.ViewModels;
using BookingTickets.DataAccess.Data.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace BookingTickets.Presentation.Controllers
{
    public class BasketController(BookingTicketsDbContext dbContext,UserManager<AppUser> userManager,QrCodeService qrCodeService) : Controller
    {
        public IActionResult Index()
        {
            var basket = HttpContext.Request.Cookies["basket"];
            List<BasketItemVm> basketItemVms ;
            if (basket != null)
            {
                basketItemVms = Newtonsoft.Json.JsonConvert.DeserializeObject<List<BasketItemVm>>(basket);
            }
            else
            {
                basketItemVms = new List<BasketItemVm>();
            }
            ViewBag.Tickets= dbContext.Tickets.Include(x => x.Event).ToList();
            return View(basketItemVms);
        }

        public IActionResult Add(int? id)
        {
            if (id == null) return NotFound();

            var ticket = dbContext.Tickets
                .Include(t => t.Event)
                .FirstOrDefault(p => p.EventId == id && p.AppUserId == null); // Satılmamış bilet axtar

            if (ticket == null)
            {
                var eventExists = dbContext.Events.FirstOrDefault(e => e.Id == id);
                if (eventExists == null) return NotFound("Belə bir event mövcud deyil!");

                ticket = new Ticket
                {
                    EventId = eventExists.Id,
                    AppUserId = null, // İstifadəçisiz yaradılır
                    PurchaseDate = DateTime.MinValue, // Hələlik alınmayıb
                    Status = TicketStatus.Available, // Yeni bilet yaradılarkən Available olmalıdır
                    ValidationToken = Guid.NewGuid().ToString()
                };

                dbContext.Tickets.Add(ticket);
                dbContext.SaveChanges(); // ✅ Ticket ID yaranır!

                // 🎯 **ID artıq var, indi QR kod yaradırıq**
                ticket.QRCodePath = qrCodeService.GenerateTicketPDF(ticket);
                dbContext.SaveChanges(); // ✅ QR kod path-i DB-də yazılır
            }

            if (User.Identity.IsAuthenticated)
            {
                var user = userManager.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                if (user == null) return NotFound("İstifadəçi tapılmadı!");

                // Bileti istifadəçiyə bağla
                ticket.AppUserId = user.Id;
                ticket.PurchaseDate = DateTime.Now;
                ticket.Status = TicketStatus.Purchased;
                ticket.ValidationToken = Guid.NewGuid().ToString();

                // 🎯 **İkinci dəfə QR kodu yenilə, çünki status dəyişdi**
                ticket.QRCodePath = qrCodeService.GenerateTicketPDF(ticket);

                dbContext.SaveChanges(); // ✅ Final update
            }

            return RedirectToAction("Index","Basket");
        }

        


        //public IActionResult Add(int? id)
        //{
        //    if (id == null) return NotFound();
        //    var ticket = dbContext.Tickets
        //        .Include(t => t.Event)
        //        .FirstOrDefault(p => p.Id == id);
        //    if (ticket == null) return NotFound();
        //    var basket = HttpContext.Request.Cookies["basket"];
        //    List<BasketItemVm> basketItemVms;
        //    if (basket == null)
        //    {
        //        basketItemVms = new();
        //    }
        //    else
        //    {
        //        basketItemVms = JsonSerializer.Deserialize<List<BasketItemVm>>(basket);
        //    }
        //    var basketItemVm = basketItemVms.FirstOrDefault(p => p.Id == id);
        //    if (basketItemVm == null)
        //    {
        //        BasketItemVm basketItem = new();
        //        basketItem.Id = ticket.Id;
        //        basketItem.Name = ticket.Event.Name;
        //        basketItem.MainImage = ticket.Event.EventImages.FirstOrDefault(x => x.Id == 1).ImagePath;

        //        basketItem.Count = 1;
        //        basketItemVms.Add(basketItem);
        //    }
        //    else
        //    {
        //        basketItemVm.Count++;
        //    }
        //    if (User.Identity.IsAuthenticated && User.IsInRole("Member"))
        //    {
        //        var user = userManager.Users.Include(u => u.BasketItems).FirstOrDefault(u => u.UserName == User.Identity.Name);
        //        var basketItem = user.BasketItems.FirstOrDefault(p => p.TicketId == id);
        //        if (basketItem is null)
        //        {
        //            BasketItem newBasketItem = new();
        //            newBasketItem.TicketId = ticket.Id;
        //            newBasketItem.Count = 1;
        //            newBasketItem.AppUserId = user.Id;
        //            user.BasketItems.Add(newBasketItem);
        //        }
        //        else
        //        {
        //            basketItem.Count++;
        //        }
        //        dbContext.SaveChanges();
        //    }
        //    HttpContext.Response.Cookies.Append("basket", JsonSerializer.Serialize(basketItemVms));
        //    return PartialView("_BasketPartial", basketItemVms);
        //}

    }
}
