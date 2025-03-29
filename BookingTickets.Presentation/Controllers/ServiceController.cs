using BookingTickets.Core.Entities;
using BookingTickets.DataAccess.Data.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.Presentation.Controllers
{
    [Authorize(Roles = "Member")]
    public class ServiceController(BookingTicketsDbContext dbContext) : Controller
    {
        public IActionResult Index()
        {
           List<Service> Services=dbContext.Services.ToList();
            return View(Services);
        }
        public IActionResult Detail(int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            Service? service = dbContext.Services.FirstOrDefault(x => x.Id == id);
            if (service == null)
            {
                return RedirectToAction("Index","Service");
            }
            return View(service);
        }
    }
}
