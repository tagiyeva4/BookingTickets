using BookingTickets.Core.ViewModels;
using BookingTickets.DataAccess.Data.Contexts;

namespace BookingTickets.Business.Services.Implementations;

public class LayoutServices
{
    private readonly BookingTicketsDbContext _dbContext;

    public LayoutServices(BookingTicketsDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Dictionary<string, string> GetSettings()
    {
        return _dbContext.Settings.ToDictionary(s => s.Key, s => s.Value);
    }
    public List<BasketItemVm> GetUserBasketItems()
    {
        var items = new List<BasketItemVm>();
        return items;
    }
}
