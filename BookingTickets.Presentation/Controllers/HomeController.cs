using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BookingTickets.Presentation.Models;
using BookingTickets.Presentation.ViewModels;
using BookingTickets.DataAccess.Data.Contexts;

namespace BookingTickets.Presentation.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly BookingTicketsDbContext _dbContext;

    public HomeController(ILogger<HomeController> logger, BookingTicketsDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        HomeVm homeVm = new HomeVm();
        homeVm.Sliders=_dbContext.Sliders.ToList();
        homeVm.SlidingTexts=_dbContext.SlidingTexts.ToList();
        homeVm.Brands=_dbContext.Brands.ToList();
        return View(homeVm);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
