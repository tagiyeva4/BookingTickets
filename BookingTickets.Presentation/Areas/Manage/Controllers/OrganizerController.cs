using BookingTickets.Core.Entities;
using BookingTickets.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.Presentation.Areas.Manage.Controllers;

[Area("Manage")]
public class OrganizerController (UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager) : Controller
{
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(OrganizerLoginVm organizerLogin, string? returnUrl)
    {
        if (!ModelState.IsValid) return View();
        var user = await _userManager.FindByNameAsync(organizerLogin.UserName);
        if (user == null || (!await _userManager.IsInRoleAsync(user, "EventOrganizer")))
        {
            ModelState.AddModelError("", "UserName or Password is incorrect...");
            return View();
        }
        var result = await _userManager.CheckPasswordAsync(user, organizerLogin.Password);
        if (!result)
        {
            ModelState.AddModelError("", "UserName or Password is incorret...");
            return View();
        }
        await _signInManager.SignInAsync(user, false);

        return returnUrl != null ? Redirect(returnUrl) : RedirectToAction("Index", "Event");

    }
    [Authorize(Roles = "EventOrganizer")]
    public async Task<IActionResult> LogOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login", "Organizer");
    }

    public async Task<IActionResult> CreateOrganizer()
    {
        AppUser user = new AppUser
        {
            UserName = "event_organizer",
            Email = "eventorganizer@gmail.com",
            FullName = "Organizer",
        };

        IdentityResult identityResult = await _userManager.CreateAsync(user, "_Event123!");

        if (identityResult.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "EventOrganizer");
        }
        else
        {
            return Json(new
            {
                Success = false,
                Errors = identityResult.Errors.Select(e => e.Description).ToList()
            });
        }

        return Json(new { Success = true });
    }

}
