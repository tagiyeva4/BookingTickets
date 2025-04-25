using BookingTickets.Core.Entities;
using BookingTickets.Core.ViewModels;
using BookingTickets.DataAccess.Data.Contexts;
using Microsoft.AspNetCore.Authorization;
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
        public IActionResult Detail(int? id)
        {
            ServiceVm serviceVm = new ServiceVm();

            serviceVm.Categories = dbContext.Categories.ToList();

            serviceVm.Services = dbContext.Services.OrderBy(p => Guid.NewGuid())
            .Take(3).ToList();

            if (id == null)
            {
                return BadRequest();
            }
            serviceVm.Service = dbContext.Services.FirstOrDefault(x => x.Id == id);

            if (serviceVm.Service == null)
            {
                return RedirectToAction("Index","Service");
            }
            return View(serviceVm);
        }
    }
}
