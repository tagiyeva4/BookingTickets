using BookingTickets.Business.Dtos.EventDtos;
using BookingTickets.Business.Services.Abstractions;
using BookingTickets.Business.Services.Implementations;
using BookingTickets.DataAccess.Data.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var dto = await eventService.GetUpdatedDtoAsync(id);

            // ViewBag-ə məlumatları əlavə etmək
            ViewBag.Venues = new SelectList(dbContext.Venues, "Id", "Name");
            ViewBag.Languages = new MultiSelectList(dbContext.Languages, "Id", "Name");
            ViewBag.Persons = new MultiSelectList(dbContext.People, "Id", "FullName");

            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(EventUpdateDto dto)
        {
            bool result = await eventService.UpdateAsync(dto, ModelState);

            if (!result)
            {
                ViewBag.Venues = new SelectList(dbContext.Venues, "Id", "Name");
                ViewBag.Languages = new MultiSelectList(dbContext.Languages, "Id", "Name");
                ViewBag.Persons = new MultiSelectList(dbContext.People, "Id", "FullName");

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
