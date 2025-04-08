using Microsoft.AspNetCore.Http;
using BookingTickets.Core.ViewModels;
using BookingTickets.DataAccess.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;


namespace BookingTickets.Business.Services.Implementations;

public class LayoutServices
{
    private readonly BookingTicketsDbContext _dbContext;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly HttpContext _httpContext;
    public LayoutServices(BookingTicketsDbContext dbContext, IHttpContextAccessor httpContextAccessor)
    {
        _dbContext = dbContext;
        _httpContextAccessor = httpContextAccessor;
        _httpContext = httpContextAccessor.HttpContext;
    }
    public Dictionary<string, string> GetSettings()
    {
        return _dbContext.Settings.ToDictionary(s => s.Key, s => s.Value);
    }
    public List<BasketItemVm> GetUserBasketItems()
    {
        List<BasketItemVm> list;

        var basket = _httpContext.Request.Cookies["basket"];

        if (!string.IsNullOrEmpty(basket))
        {
            try
            {
                list = JsonSerializer.Deserialize<List<BasketItemVm>>(basket) ?? new List<BasketItemVm>();
            }
            catch
            {
                list = new List<BasketItemVm>(); // Corrupted cookie varsa
            }
        }
        else
        {
            list = new List<BasketItemVm>();
        }

        var user = _dbContext.Users
            .Include(u => u.BasketItems)
                .ThenInclude(b => b.Ticket)
                    .ThenInclude(t => t.Event)
            .FirstOrDefault(u => u.UserName == _httpContext.User.Identity.Name);

        if (user != null)
        {
            foreach (var dbBasketItem in user.BasketItems)
            {
                if (!list.Any(b => b.Id == dbBasketItem.TicketId))
                {
                    var evt = dbBasketItem.Ticket?.Event;

                    if (evt != null)
                    {
                        BasketItemVm basketItemVm = new BasketItemVm
                        {
                            Id = dbBasketItem.TicketId,
                            Name = evt.Name,
                            Price = evt.MinPrice
                        };

                        list.Add(basketItemVm);
                    }
                }
            }
        }

        foreach (var item in list)
        {
            var existProduct = _dbContext.Tickets
                .Include(x => x.Event)
                .FirstOrDefault(t => t.Id == item.Id);

            // Null yoxlaması – problemli sətrin təhlükəsiz versiyası:
            if (existProduct?.Event != null)
            {
                item.Name = existProduct.Event.Name;
                item.Price = existProduct.Event.MinPrice;
            }
            else
            {
                item.Name = "Tədbir tapılmadı";
                item.Price = 0;
            }
        }

        _httpContext.Response.Cookies.Append("basket", JsonSerializer.Serialize(list));

        return list;
    }

    //public List<BasketItemVm> GetUserBasketItems()
    //{
    //    List<BasketItemVm> list;

    //    var basket=_httpContext.Request.Cookies["basket"];

    //    if (basket != null)
    //    {
    //        list = JsonSerializer.Deserialize<List<BasketItemVm>>(basket);
    //    }

    //    else
    //    {
    //        list = new List<BasketItemVm>();
    //    }

    //    var user=_dbContext.Users
    //        .Include(u => u.BasketItems)
    //        .ThenInclude(b => b.Ticket)
    //        .FirstOrDefault(u => u.UserName == _httpContext.User.Identity.Name);

    //    if(user != null)
    //    {
    //        foreach (var dbBasketItem in user.BasketItems)
    //        {
    //            if(!list.Any(b => b.Id == dbBasketItem.TicketId))
    //            {
    //                BasketItemVm basketItemVm = new BasketItemVm();
    //                basketItemVm.Id = dbBasketItem.TicketId;
    //                basketItemVm.Name = dbBasketItem.Ticket.Event.Name;
    //                basketItemVm.Price = dbBasketItem.Ticket.Event.MinPrice;
    //                list.Add(basketItemVm);
    //            }
    //        }
    //    }

    //    foreach (var item in list)
    //    {
    //        var existProduct = _dbContext.Tickets.Include(x => x.Event).FirstOrDefault(t => t.Id == item.Id);
    //        item.Name = existProduct.Event.Name;
    //        item.Price = existProduct.Event.MinPrice;

    //    }

    //    _httpContext.Response.Cookies.Append("basket", JsonSerializer.Serialize(list));

    //    return list;
    //}
}
