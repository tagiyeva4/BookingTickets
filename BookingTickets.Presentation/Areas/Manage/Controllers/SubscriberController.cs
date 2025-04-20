using BookingTickets.Business.Dtos.SubscriberEmailDtos;
using BookingTickets.Business.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.Presentation.Areas.Manage.Controllers;

[Area("Manage")]
//[Authorize(Roles = "Admin")]
public class SubscriberController : Controller
{
    private readonly ISubscriberService _subscriberService;

    public SubscriberController(ISubscriberService subscriberService)
    {
        _subscriberService = subscriberService;
    }

    public async Task<IActionResult> Index()
    {
        var subscribers = await _subscriberService.GetAllAsync();
        return View(subscribers);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(SubscriberCreateDto dto)
    {
        var result = await _subscriberService.CreateAsync(dto, ModelState);

        if (result is false)
        {
            return View(dto);
        }

        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Update(int id)
    {
        var result = await _subscriberService.GetUpdatedDtoAsync(id);
        if (result is null)
        {
            return NotFound();
        }
        return View(result);
    }
    [HttpPost]
    public async Task<IActionResult> Update(SubscriberUpdateDto dto)
    {
        var result = await _subscriberService.UpdateAsync(dto, ModelState);
        if (result is false)
        {
            return View(dto);
        }
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Delete(int id)
    {
        await _subscriberService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
