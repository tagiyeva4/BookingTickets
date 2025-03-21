using BookingTickets.Core.Entities;
using BookingTickets.Core.Enums;
using BookingTickets.DataAccess.Data.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.Presentation.Controllers
{
    public class BlogController(BookingTicketsDbContext _dbContext,UserManager<AppUser> _userManager) : Controller
    {
        public IActionResult Index()
        {
           var blogs= _dbContext.Blogs.Include(b=>b.BlogImages).ToList();  
            return View(blogs);
        }
        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var existBlog  =_dbContext.Blogs.Include(b=>b.BlogImages).Include(b=>b.BlogComments).FirstOrDefault(b=>b.Id == id);
            if(existBlog == null)
            {
                return NotFound();
            }
            return View(existBlog);
        }
    }
}
