using BookingTickets.Core.Entities;
using BookingTickets.Core.ViewModels;
using BookingTickets.DataAccess.Data.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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
                basketItemVms = JsonConvert.DeserializeObject<List<BasketItemVm>>(basket);
            }
            else
            {
                basketItemVms = new List<BasketItemVm>();
            }
            return View(basketItemVms);
        }
        //public IActionResult Add(int? id)
        //{
        //    if (id == null) return NotFound();
        //    var ticket = dbContext.Tickets
        //        .Include(t=>t.Event)
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
        //        basketItem.MainImage =ticket.Event.EventImages.FirstOrDefault(x=>x.Id==1).ImagePath;
                
        //        basketItem.Count = 1;
        //        basketItemVms.Add(basketItem);
        //    }
        //    else
        //    {
        //        basketItemVm.Count++;
        //    }
        //    if (User.Identity.IsAuthenticated && User.IsInRole("member"))
        //    {
        //        var user = userManager.Users.Include(u => u.BasketItems).FirstOrDefault(u => u.UserName == User.Identity.Name);
        //        var basketItem = user.BasketItems.FirstOrDefault(p => p.ProductId == id);
        //        if (basketItem is null)
        //        {
        //            BasketItem newBasketItem = new();
        //            newBasketItem.ProductId = product.Id;
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
