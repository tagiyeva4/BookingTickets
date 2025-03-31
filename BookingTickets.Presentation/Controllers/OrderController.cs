using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.Presentation.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
