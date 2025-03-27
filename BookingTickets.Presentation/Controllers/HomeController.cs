using BookingTickets.DataAccess.Data.Contexts;
using BookingTickets.Presentation.Models;
using BookingTickets.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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

    public IActionResult Search(string search)
    {
        if (!string.IsNullOrWhiteSpace(search))
        {
            var data = _dbContext.Events
                .Include(x => x.Venue)
                .Include(x => x.EventLanguages)
                .ThenInclude(el => el.Language)
                .Include(x => x.EventPersons)
                .ThenInclude(xp => xp.Person)
                .Where(x => x.IsAccess == true &&
                           (x.Name.ToLower().Contains(search.ToLower()) ||
                            x.Description.ToLower().Contains(search.ToLower())))
                .ToList();
            return PartialView("_SearchPartial", data);
        }
        else
        {
            return NotFound();
        }
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
