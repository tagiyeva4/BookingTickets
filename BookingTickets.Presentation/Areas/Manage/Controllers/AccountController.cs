using BookingTickets.Core.Entities;
using BookingTickets.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.Presentation.Areas.Manage.Controllers;

[Area("Manage")]
public class AccountController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(AdminLoginVm adminLoginVm, string? returnUrl)
    {
        if (!ModelState.IsValid) return View();
        var user = await _userManager.FindByNameAsync(adminLoginVm.UserName);
        if (user == null || (!await _userManager.IsInRoleAsync(user, "Admin") && !await _userManager.IsInRoleAsync(user, "EventOrganizer")))
        {
            ModelState.AddModelError("", "UserName or Password is incorret...");
            return View();
        }
        var result = await _userManager.CheckPasswordAsync(user, adminLoginVm.Password);
        if (!result)
        {
            ModelState.AddModelError("", "UserName or Password is incorret...");
            return View();
        }
        await _signInManager.SignInAsync(user, false);

        return returnUrl != null ? Redirect(returnUrl) : RedirectToAction("Index", "Dashboard");

    }
    [Authorize(Roles = "EventOrganizer,Admin")]
    public async Task<IActionResult> LogOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login", "Account");
    }
    public async Task<IActionResult> CreateAdminUser()
    {
        AppUser user = new AppUser
        {
            UserName = "_admin",
            Email = "admin@gmail.com",
            FullName = "Admin",
        };
        IdentityResult identityResult = await _userManager.CreateAsync(user, "Admin123!");
        await _userManager.AddToRoleAsync(user, "Admin");
        return Json(identityResult);
    }
}
