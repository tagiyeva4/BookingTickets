using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.Presentation.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
