using BookingTickets.Business.Dtos.BlogDtos;
using BookingTickets.Business.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.Presentation.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "Admin")]
    public class BlogController(IBlogService blogService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var blogs=await blogService.GetAllAsync();
            return View(blogs);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogCreateDto dto)
        {
            var result = await blogService.CreateAsync(dto, ModelState);
            if (result is false)
            {
                return View(dto);
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            await blogService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            var result = await blogService.GetUpdatedDtoAsync(id);
            if (result is null)
            {
                return NotFound();
            }
            return View(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(BlogUpdateDto dto)
        {
            var result = await blogService.UpdateAsync(dto, ModelState);
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
            var result=await blogService.GetAsync(id);
            if (result is null)
            {
                return NotFound();
            }
            return View(result);
        }
    }
}
