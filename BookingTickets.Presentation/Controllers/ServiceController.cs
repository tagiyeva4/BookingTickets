using BookingTickets.Core.Entities;
using BookingTickets.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.Presentation.Controllers
{
    public class ServiceController(BookingTicketsDbContext dbContext) : Controller
    {
        public IActionResult Index()
        {
           List<Service> Services=dbContext.Services.ToList();
            return View(Services);
        }
        public IActionResult Detail(int id)
        {
            Service? service = dbContext.Services.FirstOrDefault(x => x.Id == id);
            if (service == null)
            {
                return RedirectToAction("Index","Service");
            }
            return View(service);
        }
    }
}
