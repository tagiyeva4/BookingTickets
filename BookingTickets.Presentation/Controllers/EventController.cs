using BookingTickets.Core.Entities;
using BookingTickets.Core.Enums;
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
                .Include(e => e.EventsSchedules)
                .ThenInclude(es => es.Schedule)
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
                .ThenInclude(v => v.Seats)
                .Include(e => e.EventsSchedules)
                .ThenInclude(es => es.Schedule)
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

        [HttpGet]
        public async Task<IActionResult> GetReservedSeats(int eventId, int scheduleId)
        {
            var reservedSeatIds = await dbContext.Tickets
                .Where(t => t.EventId == eventId &&
                            t.ScheduleId == scheduleId &&
                            t.Status != TicketStatus.Cancelled &&
                            t.ExpiresAt > DateTime.Now)
                .Select(t => t.VenueSeatId)
                .ToListAsync();

            return Json(reservedSeatIds);
        }

    }
}
