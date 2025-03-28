using BookingTickets.DataAccess.Data.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.Presentation.Controllers
{
    public class EventController(BookingTicketsDbContext dbContext) : Controller
    {
        public IActionResult Index()
        {
            var events=dbContext.Events
                .Include(e => e.Venue)
                .Include(e => e.EventImages)
                .Include(e => e.EventPersons)
                .ThenInclude(ep => ep.Person)
                .Include(e => e.EventLanguages)
                .ThenInclude(el => el.Language)
                .Where(e => e.IsAccess == true).ToList();

            return View(events);
        }
        public IActionResult Detail(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var existEvent =dbContext.Events
                .Include(e=>e.Venue)
                .Include(e=>e.EventImages)
                .Include(e=>e.EventPersons)
                .ThenInclude(ep=>ep.Person)
                .Include(e=>e.EventLanguages)
                .ThenInclude(el=>el.Language)
                .Where(e=>e.IsAccess==true)
                .FirstOrDefault(e=>e.Id==id) ;
            if (existEvent == null)
            {
                return NotFound();
            }
                return View(existEvent);
        }
    }
}
