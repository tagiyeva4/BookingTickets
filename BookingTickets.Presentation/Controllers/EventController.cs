using BookingTickets.Core.Entities;
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
        [HttpGet("GetVenueLocation")]
        public IActionResult GetVenueLocation()
        {
            var venue = new Venue
            {
                Name = "Nümunə Konsert Zalı",
                Address = "Bakı, Fəvvarələr Meydanı",
                Latitude = 40.4093, // Bakı şəhərinin enliyi
                Longitude = 49.8671 // Bakı şəhərinin uzunluğu
            };

            return Ok(new
            {
                venue.Name,
                venue.Address,
                venue.Latitude,
                venue.Longitude
            });
        }

    }
}
