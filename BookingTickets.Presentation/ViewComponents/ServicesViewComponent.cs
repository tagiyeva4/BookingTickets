using BookingTickets.Core.Entities;
using BookingTickets.DataAccess.Data.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.Presentation.ViewComponents
{
    public class ServicesViewComponent:ViewComponent
    {
        private readonly BookingTicketsDbContext _dbContext;

        public ServicesViewComponent(BookingTicketsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync(int? take=null)
        {
            IQueryable<Service> services = _dbContext.Services.OrderBy(x => x.Id);

            if (take.HasValue)
            {
                services = services.Take(take.Value);
            }

            var servicesList = await services.ToListAsync();

            return View(servicesList);
        }
    }
}
