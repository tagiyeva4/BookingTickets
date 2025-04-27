using BookingTickets.Business.Dtos.TagDtos;
using BookingTickets.Business.Services;
using BookingTickets.Business.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.Presentation.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "Admin")]
    public class TagController(ITagService tagService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var tags=await tagService.GetAllAsync();
            return View(tags);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TagCreateDto dto)
        {
            var result = await tagService.CreateAsync(dto, ModelState);
            if(result is false)
            {
                return View(dto);
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            await tagService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            var result=await tagService.GetUpdatedDtoAsync(id);
            if (result is null)
            {
                return NotFound();
            }
            return View(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(TagUpdateDto dto)
        {
            var result=await tagService.UpdateAsync(dto,ModelState);
            if (result is false)
            {
                return View(dto);
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Detail(int id)
        {
            if (id==null)
            {
                return BadRequest();
            }
            var result=await tagService.GetAsync(id);
            if (result is null)
            {
                return NotFound();
            }
            return View(result);
        }
    }
}
