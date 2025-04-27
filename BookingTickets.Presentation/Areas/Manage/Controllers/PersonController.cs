using BookingTickets.Business.Dtos.PersonDtos;
using BookingTickets.Business.Services.Abstractions;
using BookingTickets.DataAccess.Data.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookingTickets.Presentation.Areas.Manage.Controllers;
[Area("Manage")]
[Authorize(Roles = "Admin")]
public class PersonController(IPersonService service,BookingTicketsDbContext dbContext) : Controller
{
    public async Task<IActionResult> Index()
    {
        var people = await service.GetAllAsync();

        return View(people);
    }
    public IActionResult Create()
    {
        ViewBag.Professions = dbContext.Professions.ToList();

        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(PersonCreateDto dto)
    {
        ViewBag.Professions = dbContext.Professions.ToList();

        var result = await service.CreateAsync(dto, ModelState);

        if (result is false)
        {
            return View(dto);
        }

        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Delete(int id)
    {
        await service.DeleteAsync(id);

        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Update(int id)
    {
        ViewBag.Professions = dbContext.Professions.ToList();

        var result = await service.GetUpdatedDtoAsync(id);

        if (result is null)
        {
            return NotFound();
        }
        
        return View(result);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(PersonUpdateDto dto)
    {
        ViewBag.Professions = dbContext.Professions.ToList();

        var result = await service.UpdateAsync(dto, ModelState);

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
        var result = await service.GetAsync(id);

        if (result is null)
        {
            return NotFound();
        }

        return View(result);
    }
}
