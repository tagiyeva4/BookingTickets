using BookingTickets.Business.Dtos.VenueDtos;
using BookingTickets.Business.Services.Abstractions;
using BookingTickets.DataAccess.Data.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.Presentation.Areas.Manage.Controllers;

[Area("Manage")]
//[Authorize(Roles = "Admin")]
public class VenueController(IVenueService venueService,BookingTicketsDbContext dbContext) : Controller
{
    public async Task<IActionResult> Index()
    {
        var venues = await venueService.GetAllAsync();  
        return View(venues);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(VenueCreateDto dto)
    {
        var result = await venueService.CreateAsync(dto, ModelState);
        if (result is false)
        {
            return View(dto);
        }
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Delete(int id)
    {
        await venueService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
    public async Task<ActionResult> Update(int id)
    {
        var result=await venueService.GetUpdatedDtoAsync(id);
        if (result is null)
        {
            return NotFound();
        }
        return View(result);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(VenueUpdateDto dto)
    {
        var result=await venueService.UpdateAsync(dto, ModelState);
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
        var result=await venueService.GetAsync(id);
        if (result is null)
        {
            return NotFound();
        }
        return View(result);
    }


    [HttpGet]
    public async Task<IActionResult> GetSeatsByVenueId(int venueId)
    {
        var seats = await dbContext.VenueSeats
            .Where(x => x.VenueId == venueId)
            .Select(x => new
            {
                id = x.Id,
                seatLabel = x.SeatLabel
            })
            .ToListAsync();

        return Json(seats);
    }

}
