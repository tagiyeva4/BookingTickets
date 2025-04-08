using BookingTickets.Business.Services.Abstractions;
using BookingTickets.Core.Enums;
using BookingTickets.Core.ViewModels;
using BookingTickets.DataAccess.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.Business.Services.Implementations;

public class BasketService : IBasketService
{
    private readonly BookingTicketsDbContext dbContext;

    public BasketService(BookingTicketsDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<List<BasketItemVm>> GetUserBasketAsync(string userId)
    {
        var tickets = await dbContext.Tickets
            .Include(t => t.Event)
            .Include(t => t.VenueSeat)
            .Where(t => t.AppUserId == userId &&
                        t.Status == TicketStatus.Reserved &&
                        t.ExpiresAt > DateTime.Now)
            .ToListAsync();

        return tickets.Select(t => new BasketItemVm
        {
            Id = t.Id,
            Name = $"Seat {t.VenueSeat?.SeatLabel}",
            SeatLocation = $"{t.VenueSeat?.RowNumber}-ci sıra, {t.VenueSeat?.SeatNumber}-ci yer",
            Price = t.Price,
            Count = 1,
            EventName = t.Event.Name,
            QRCodePath = null
        }).ToList();
    }
}
