using BookingTickets.Business.Dtos.EventDtos;
using BookingTickets.Business.Services.Abstractions;
using BookingTickets.DataAccess.Data.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.Presentation.Areas.Manage.Controllers
{
    [Area("Manage")]
    //[Authorize(Roles = "EventOrganizer")]
    public class EventController (IEventService eventService,BookingTicketsDbContext dbContext): Controller
    {
        public async Task<IActionResult> Index()
        {
            var @events=await eventService.GetAllAsync();
            return View(@events);
        }
        public IActionResult Create()
        {
            ViewBag.Languages = dbContext.Languages.ToList();
            ViewBag.Venues = dbContext.Venues.ToList();
            ViewBag.Persons = dbContext.People.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventCreateDto dto)
        {
            ViewBag.Languages=dbContext.Languages.ToList();
            ViewBag.Venues=dbContext.Venues.ToList();
            ViewBag.Persons = dbContext.People.ToList();
            var result = await eventService.CreateAsync(dto, ModelState);
            if (result is false)
            {
                return View(dto);
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            await eventService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<ActionResult> Update(int id)
        {
            ViewBag.Languages = dbContext.Languages.ToList();
            ViewBag.Venues = dbContext.Venues.ToList();
            ViewBag.Persons = dbContext.People.ToList();
            ViewBag.Schedules = dbContext.Schedules.ToList();
            var result=await eventService .GetUpdatedDtoAsync(id);
            if (result is null)
            {
                return NotFound();
            }
            return View(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(EventUpdateDto dto)
        {
            ViewBag.Languages = dbContext.Languages.ToList();
            ViewBag.Venues = dbContext.Venues.ToList();
            ViewBag.Persons = dbContext.People.ToList();
            var result=await eventService.UpdateAsync(dto,ModelState);
            if (result is false)
            {
                return View(dto);
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Detail(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var result=await eventService.GetAsync(id);
            if (result is null)
            {
                return NotFound();
            }
            return View(result);
        }
    }
}
