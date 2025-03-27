using BookingTickets.DataAccess.Data.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookingTickets.Presentation.Areas.Manage.Controllers;

[Area("Manage")]
//[Authorize(Roles = "Admin")]
public class SaleController(BookingTicketsDbContext dbContext) : Controller
{
    public IActionResult Access()
    {
        var events = dbContext.Events
              .Include(x => x.Venue)
              .Include(x => x.EventLanguages)
              .ThenInclude(el => el.Language)
              .Include(x => x.EventPersons)
              .ThenInclude(xp => xp.Person)
              .ToList();
        return View(events);
    }
    [HttpPost]
    public IActionResult Access(bool isAccess, int eventId)
    {
        var eventItem = dbContext.Events.FirstOrDefault(e => e.Id==eventId);

        if (eventItem != null)
        {
            eventItem.IsAccess = isAccess;
            dbContext.SaveChanges();

        }
        else
        {
            return NotFound();
        }

        return RedirectToAction("Access");
    }

}
