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
    public class BasketController(BookingTicketsDbContext dbContext,UserManager<AppUser> userManager) : Controller
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
                ValidationToken = Guid.NewGuid().ToString()
            };

            dbContext.Tickets.Add(ticket);
            dbContext.SaveChanges();

            TempData["Success"] = "Ticket added to basket.";
          return RedirectToAction("Detail", "Event", new { id = eventId });
        }

       

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult ReserveTicket(int eventId, int seatId)
        //{
        //    var seat = dbContext.VenueSeats.FirstOrDefault(s => s.Id == seatId);
        //    if (seat == null) return Json(new { success = false, message = "Seat not found" });

        //    var @event = dbContext.Events
        //        .Include(e => e.Tickets)
        //        .Include(e => e.Venue)
        //        .FirstOrDefault(e => e.Id == eventId);

        //    if (@event == null) return Json(new { success = false, message = "Event not found" });

        //    var isTaken = dbContext.Tickets.Any(t =>
        //        t.VenueSeatId == seatId &&
        //        (t.Status == TicketStatus.Purchased ||
        //         (t.Status == TicketStatus.Reserved && t.ExpiresAt > DateTime.Now)));

        //    if (isTaken)
        //        return Json(new { success = false, message = "This seat is already taken." });

        //    var ticket = new Ticket
        //    {
        //        EventId = eventId,
        //        VenueSeatId = seatId,
        //        Status = TicketStatus.Reserved,
        //        Price = seat.Price,
        //        ReservedAt = DateTime.Now,
        //        ExpiresAt = DateTime.Now.AddMinutes(15),
        //        ValidationToken = Guid.NewGuid().ToString()
        //    };

        //    dbContext.Tickets.Add(ticket);
        //    dbContext.SaveChanges();

        //    return Json(new { success = true, message = "Ticket added to basket" });
        //}


        //public IActionResult AddToBasket(int eventId, int seatId)
        //{
        //    var seat = dbContext.VenueSeats.FirstOrDefault(s => s.Id == seatId);
        //    if (seat == null) return NotFound();

        //    var @event = dbContext.Events
        //        .Include(e => e.Tickets)
        //        .Include(e => e.Venue)
        //        .FirstOrDefault(e => e.Id == eventId);

        //    if (@event == null) return NotFound();

        //    var isSold = dbContext.Tickets.Any(t => t.VenueSeatId == seatId &&
        //        (t.Status == TicketStatus.Purchased || t.Status == TicketStatus.Available));

        //    if (isSold)
        //    {
        //        return BadRequest("Bu yer artıq alınıb.");
        //    }

        //    // Qiyməti götür — bu sənin sistemindən asılıdır. Məsələn:
        //    var price = seat.Price; // ya event.DefaultPrice, ya seat.Price — nə varsa

        //    var ticket = new Ticket
        //    {
        //        EventId = eventId,
        //        VenueSeatId = seatId,
        //        AppUserId = null,
        //        Status = TicketStatus.Available,
        //        PurchaseDate = DateTime.MinValue,
        //        ValidationToken = Guid.NewGuid().ToString(),
        //        Price = price
        //    };

        //    dbContext.Tickets.Add(ticket);
        //    dbContext.SaveChanges();

        //    ticket.QRCodePath = qrCodeService.GenerateTicketPDF(ticket);
        //    dbContext.SaveChanges();

        //    if (User.Identity.IsAuthenticated)
        //    {
        //        var userId = userManager.GetUserId(User);
        //        if (!string.IsNullOrEmpty(userId))
        //        {
        //            var basket = dbContext.Baskets.FirstOrDefault(b => b.AppUserId == userId);
        //            if (basket == null)
        //            {
        //                basket = new Basket { AppUserId = userId };
        //                dbContext.Baskets.Add(basket);
        //                dbContext.SaveChanges();
        //            }

        //            var basketItem = new BasketItem
        //            {
        //                BasketId = basket.Id,
        //                TicketId = ticket.Id,
        //                AppUserId = userId
        //            };

        //            dbContext.BasketItems.Add(basketItem);

        //            // Satılmış statusuna keçirik
        //            ticket.AppUserId = userId;
        //            ticket.PurchaseDate = DateTime.Now;
        //            ticket.Status = TicketStatus.Purchased;
        //            ticket.ValidationToken = Guid.NewGuid().ToString();
        //            ticket.QRCodePath = qrCodeService.GenerateTicketPDF(ticket);

        //            dbContext.SaveChanges();
        //        }
        //    }

        //    return RedirectToAction("Index", "Basket");
        //}


        // Controller metodu
        //public IActionResult AddToBasket(int eventId, int seatId)
        //{
        //    var seat = dbContext.VenueSeats.FirstOrDefault(s => s.Id == seatId);
        //    if (seat == null) return NotFound();

        //    var @event = dbContext.Events
        //        .Include(e => e.Tickets)
        //        .Include(e => e.Venue)
        //        .FirstOrDefault(e => e.Id == eventId);

        //    if (@event == null) return NotFound();

        //    // Yoxlayaq ki, bu yer artıq satılıb ya yox
        //    var isSold = dbContext.Tickets.Any(t => t.VenueSeatId == seatId &&
        //        (t.Status == TicketStatus.Purchased || t.Status == TicketStatus.Available));

        //    if (isSold)
        //    {
        //        return BadRequest("Bu yer artıq alınıb.");
        //    }

        //    // Bilet yaradırıq (qiymət olmadan)
        //    var ticket = new Ticket
        //    {
        //        EventId = eventId,
        //        VenueSeatId = seatId,
        //        AppUserId = null,
        //        Status = TicketStatus.Available,
        //        PurchaseDate = DateTime.MinValue,
        //        ValidationToken = Guid.NewGuid().ToString()
        //    };

        //    dbContext.Tickets.Add(ticket);
        //    dbContext.SaveChanges();

        //    // QR kod generasiyası
        //    ticket.QRCodePath = qrCodeService.GenerateTicketPDF(ticket);
        //    dbContext.SaveChanges();

        //    // İstifadəçi daxil olubsa, bileti birbaşa onun səbətinə əlavə edirik
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        var userId = userManager.GetUserId(User);
        //        if (!string.IsNullOrEmpty(userId))
        //        {
        //            // Səbəti yoxlayırıq, yoxdursa yaradırıq
        //            var basket = dbContext.Baskets.FirstOrDefault(b => b.AppUserId == userId);
        //            if (basket == null)
        //            {
        //                basket = new Basket { AppUserId = userId };
        //                dbContext.Baskets.Add(basket);
        //                dbContext.SaveChanges();
        //            }

        //            // Bileti səbətə əlavə edirik
        //            var basketItem = new BasketItem
        //            {
        //                BasketId = basket.Id,
        //                TicketId = ticket.Id,
        //                DateAdded = DateTime.Now
        //            };

        //            dbContext.BasketItems.Add(basketItem);

        //            // Bileti satın alınmış statusuna keçirmək
        //            ticket.AppUserId = userId;
        //            ticket.PurchaseDate = DateTime.Now;
        //            ticket.Status = TicketStatus.Purchased;
        //            ticket.ValidationToken = Guid.NewGuid().ToString();

        //            // QR kodu yenidən yaratmaq lazımdır çünki məlumatlar dəyişdi
        //            ticket.QRCodePath = qrCodeService.GenerateTicketPDF(ticket);

        //            dbContext.SaveChanges();
        //        }
        //    }

        //    return RedirectToAction("Index", "Basket");
        //}

        // Oturacaq qiymətini hesablayan metod - nümayiş üçün frontend-də istifadə edilə bilər
        private decimal CalculateSeatPrice(Event @event, VenueSeat seat)
        {
            // Səhnəyə yaxınlığı hesablayaq (bu misalda sıra nömrəsinə görə)
            // Nə qədər kiçik sıra nömrəsi, o qədər yaxın
            int rowCount = dbContext.VenueSeats
                .Where(s => s.VenueId == @event.VenueId)
                .Select(s => s.RowNumber)
                .Distinct()
                .Count();

            if (rowCount <= 1) return @event.MaxPrice; // Əgər tək sıra varsa, hamısı maksimum qiymət

            // Səhnəyə yaxınlığa əsasən qiymət hesablama
            // Sıra 1-dirsə (ən yaxın), ən yüksək qiymət
            if (seat.RowNumber == 1)
            {
                return @event.MaxPrice;
            }

            // Sıra sonuncudursa (ən uzaq), ən aşağı qiymət
            if (seat.RowNumber == rowCount)
            {
                return @event.MinPrice;
            }

            // Əks halda, sıra nömrəsinə əsasən aralıq qiymət hesablayırıq
            decimal priceRange = @event.MaxPrice - @event.MinPrice;
            decimal priceStep = priceRange / (rowCount - 1);

            // (Sıra nömrəsi - 1) * qiymət fərqi hər sıra üçün
            decimal discount = (seat.RowNumber - 1) * priceStep;

            return @event.MaxPrice - discount;
        }


        //public IActionResult AddToBasket(int eventId, int seatId)
        //{
        //    var seat = dbContext.VenueSeats.FirstOrDefault(s => s.Id == seatId);
        //    if (seat == null) return NotFound();

        //    var @event = dbContext.Events.Include(e => e.Tickets).FirstOrDefault(e => e.Id == eventId);
        //    if (@event == null) return NotFound();

        //    var isSold = dbContext.Tickets.Any(t => t.VenueSeatId == seatId && t.Status == TicketStatus.Purchased);
        //    if (isSold)
        //    {
        //        return BadRequest("Bu yer artıq alınıb.");
        //    }

        //    var ticket = new Ticket
        //    {
        //        EventId = eventId,
        //        VenueSeatId = seatId,
        //        AppUserId = null,
        //        Status = TicketStatus.Available,
        //        PurchaseDate = DateTime.MinValue,
        //        ValidationToken = Guid.NewGuid().ToString()
        //    };

        //    dbContext.Tickets.Add(ticket);
        //    dbContext.SaveChanges();

        //    ticket.QRCodePath = qrCodeService.GenerateTicketPDF(ticket);
        //    dbContext.SaveChanges();

        //    if (User.Identity.IsAuthenticated)
        //    {
        //        var user = userManager.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
        //        if (user != null)
        //        {
        //            ticket.AppUserId = user.Id;
        //            ticket.PurchaseDate = DateTime.Now;
        //            ticket.Status = TicketStatus.Purchased;
        //            ticket.ValidationToken = Guid.NewGuid().ToString();
        //            ticket.QRCodePath = qrCodeService.GenerateTicketPDF(ticket);
        //            dbContext.SaveChanges();
        //        }
        //    }

        //    return RedirectToAction("Index", "Basket");
        //}


        //public IActionResult Add(int? id)
        //{
        //    if (id == null) return NotFound();

        //    var ticket = dbContext.Tickets
        //        .Include(t => t.Event)
        //        .FirstOrDefault(p => p.EventId == id && p.AppUserId == null); // Satılmamış bilet axtar

        //    if (ticket == null)
        //    {
        //        var eventExists = dbContext.Events.FirstOrDefault(e => e.Id == id);
        //        if (eventExists == null) return NotFound("Belə bir event mövcud deyil!");

        //        ticket = new Ticket
        //        {
        //            EventId = eventExists.Id,
        //            AppUserId = null, // İstifadəçisiz yaradılır
        //            PurchaseDate = DateTime.MinValue, // Hələlik alınmayıb
        //            Status = TicketStatus.Available, // Yeni bilet yaradılarkən Available olmalıdır
        //            ValidationToken = Guid.NewGuid().ToString()
        //        };

        //        dbContext.Tickets.Add(ticket);
        //        dbContext.SaveChanges(); // ✅ Ticket ID yaranır!

        //        // 🎯 **ID artıq var, indi QR kod yaradırıq**
        //        ticket.QRCodePath = qrCodeService.GenerateTicketPDF(ticket);
        //        dbContext.SaveChanges(); // ✅ QR kod path-i DB-də yazılır
        //    }

        //    if (User.Identity.IsAuthenticated)
        //    {
        //        var user = userManager.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
        //        if (user == null) return NotFound("İstifadəçi tapılmadı!");

        //        // Bileti istifadəçiyə bağla
        //        ticket.AppUserId = user.Id;
        //        ticket.PurchaseDate = DateTime.Now;
        //        ticket.Status = TicketStatus.Purchased;
        //        ticket.ValidationToken = Guid.NewGuid().ToString();

        //        // 🎯 **İkinci dəfə QR kodu yenilə, çünki status dəyişdi**
        //        ticket.QRCodePath = qrCodeService.GenerateTicketPDF(ticket);

        //        dbContext.SaveChanges(); // ✅ Final update
        //    }

        //    return RedirectToAction("Index","Basket");
        //}




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
