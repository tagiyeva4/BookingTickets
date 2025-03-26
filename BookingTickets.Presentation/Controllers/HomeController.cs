using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BookingTickets.Presentation.Models;
using BookingTickets.Presentation.ViewModels;
using BookingTickets.DataAccess.Data.Contexts;
using Microsoft.EntityFrameworkCore;

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
       homeVm.Blogs = _dbContext.Blogs.Take(3).Include(x => x.BlogImages).ToList();
        homeVm.Events = _dbContext.Events.Include(x=>x.Venue).Include(x=>x.EventLanguages).ThenInclude(el=>el.Language).Include(x=>x.EventPersons).ThenInclude(xp=>xp.Person).Where(x=>x.IsAccess==true).ToList();
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
