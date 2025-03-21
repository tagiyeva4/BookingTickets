using BookingTickets.Business.Dtos.SliderDtos;
using BookingTickets.Business.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.Presentation.Areas.Manage.Controllers;

[Area("Manage")]
//[Authorize(Roles = "Admin")]
public class SliderController(ISliderService sliderService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var sliders = await sliderService.GetAllAsync();
        return View(sliders);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(SliderCreateDto dto)
    {
        var result = await sliderService.CreateAsync(dto, ModelState);
        if(result is false)
        {
            return View(dto);
        }
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Delete(int id)
    {
        await sliderService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult>Update(int id)
    {
        var result=await sliderService.GetUpdatedDtoAsync(id);
        if(result is null)
        {
            return NotFound();
        }
        return View(result);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(SliderUpdateDto dto)
    {
        var result = await sliderService.UpdateAsync(dto, ModelState);
        if(result is false)
        {
            return View(dto) ;
        }
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult>Detail(int id)
    {
        if(id ==null)
        {
            return BadRequest();
        }
        var result=await sliderService.GetAsync(id);
        if (result is null)
        {
            return NotFound();
        }
        return View(result);

    }
}
