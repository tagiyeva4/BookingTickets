using BookingTickets.Core.ViewModels;

namespace BookingTickets.Business.Services.Abstractions;

public interface IBasketService
{
    Task<List<BasketItemVm>> GetUserBasketAsync(string userId);
}
