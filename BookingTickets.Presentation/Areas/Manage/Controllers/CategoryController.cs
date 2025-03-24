using BookingTickets.Business.Dtos.CategoryDtos;
using BookingTickets.Business.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.Presentation.Areas.Manage.Controllers;

[Area("Manage")]
//[Authorize(Roles = "Admin")]
public class CategoryController(ICategoryService categoryService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var categories=await categoryService.GetAllAsync();
        return View(categories);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult>Create(CategoryCreateDto dto)
    {
        var result = await categoryService.CreateAsync(dto, ModelState);
        if (result is false)
        {
            return View(dto);
        }
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Delete(int id)
    {
        await categoryService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Update(int id)
    { 
        var result=await categoryService.GetUpdatedDtoAsync(id);
        if (result is null)
        {
            return NotFound();
        }
        return View(result);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(CategoryUpdateDto dto)
    {
        var result= await categoryService.UpdateAsync(dto,ModelState);
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
        var result = await categoryService.GetAsync(id);
        if (result is null)
        {
            return NotFound();
        }
        return View(result);
    }

}
