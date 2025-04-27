using BookingTickets.Business.Services.Abstractions;
using BookingTickets.DataAccess.Data.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookingTickets.Presentation.Areas.Manage.Controllers;

[Area("Manage")]
[Authorize(Roles = "Admin")]
public class SaleController(BookingTicketsDbContext dbContext, IEmailService _emailService) : Controller
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
        var eventItem = dbContext.Events.FirstOrDefault(e => e.Id == eventId);

        if (eventItem != null)
        {
            eventItem.IsAccess = isAccess;
            dbContext.SaveChanges();

            if (isAccess)
            {
                var subscribers = dbContext.SubscribeEmails.Select(s => s.Email).ToList();

                foreach (var email in subscribers)
                {
                    var link = Url.Action("Detail", "Event", new { id = eventItem.Id, area = "" }, Request.Scheme);
                    
                    var subject = "🎉 New Event!";


                    var body = $@"
  <div style='font-family: Arial, sans-serif; max-width: 600px; margin: 40px auto; background: #ffffff; padding: 30px; border: 1px solid #e0e0e0; border-radius: 10px; box-shadow: 0 4px 8px rgba(0,0,0,0.1);'>
    <div style='text-align: center;'>
        <h2 style='color: #2d3748; margin-bottom: 10px;'>🎉 Your Event Is Now Live!</h2>
        <p style='font-size: 16px; color: #4a5568; margin-bottom: 30px;'>A new event has been approved for you:</p>
    </div>
    <div style='background: #f9fafb; padding: 20px; border-radius: 8px; margin-bottom: 30px;'>
        <h3 style='color: #2c5282; margin-bottom: 10px;'>{eventItem.Name}</h3>
        <p style='margin: 0; font-size: 15px; color: #718096;'>{eventItem.Description}</p>
    </div>
    <div style='text-align: center;'>
        <a href='{link}' style='display: inline-block; background-color: #3182ce; color: white; padding: 12px 30px; border-radius: 5px; font-size: 16px; text-decoration: none; font-weight: bold;'>
            View Event
        </a>
    </div>
    <p style='font-size: 13px; color: #a0aec0; text-align: center; margin-top: 30px;'>
        If you received this email by mistake, please ignore it or unsubscribe.
    </p>
</div>";


                    _emailService.SendEmail(email, subject, body);
                }
            }
        }
        else
        {
            return NotFound();
        }

        return RedirectToAction("Access");
    }

}
