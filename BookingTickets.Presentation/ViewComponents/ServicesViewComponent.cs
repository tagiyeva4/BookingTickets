using BookingTickets.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.Presentation.ViewComponents
{
    public class ServicesViewComponent:ViewComponent
    {
        private readonly BookingTicketsDbContext _dbContext;

        public ServicesViewComponent(BookingTicketsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var services=_dbContext.Services.ToList(); 
            return View(await Task.FromResult(services));
        }
    }
}
