using BookingTickets.Core.Entities;
using BookingTickets.Core.Enums;
using BookingTickets.Core.ViewModels;
using BookingTickets.DataAccess.Data.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BookingTickets.Presentation.Controllers
{
    public class BlogController(BookingTicketsDbContext _dbContext,UserManager<AppUser> _userManager) : Controller
    {
        public IActionResult Index()
        {
           var blogs= _dbContext.Blogs.Include(b=>b.BlogImages).ToList();  
            return View(blogs);
        }
        private BlogDetailVm getBlogDetailVm(int blogId)
        {
            var existBlog = _dbContext.Blogs
                .Include(b => b.BlogImages)
                .Include(b => b.BlogComments)
                .ThenInclude(bc => bc.AppUser)
                .FirstOrDefault(b => b.Id == blogId);
            BlogDetailVm blogDetailVm = new BlogDetailVm()
            {
                Blog = existBlog,
                HasCommentUser = _dbContext.BlogsComment.Any(x => x.BlogId == blogId && x.CommentStatus == CommentStatus.Accepted),
            };
            blogDetailVm.TotalCommentsCount = existBlog.BlogComments.Count(x => x.Id != existBlog.Id);
            return blogDetailVm;
        }
        private BlogDetailVm getBlogDetailVm(int blogId, string userId)
        {
            var existBlog = _dbContext.Blogs
                .Include(b => b.BlogImages)
                .Include(b => b.BlogComments)
                .ThenInclude(bc => bc.AppUser)
                .FirstOrDefault(b => b.Id == blogId);
            BlogDetailVm blogDetailVm = new BlogDetailVm()
            {
                Blog = existBlog,
                HasCommentUser = _dbContext.BlogsComment.Any(x => x.BlogId == blogId && x.CommentStatus == CommentStatus.Accepted),
            };
            blogDetailVm.TotalCommentsCount = existBlog.BlogComments.Count(x => x.Id != existBlog.Id);
            return blogDetailVm;
        }
        public async Task<IActionResult> Detail(int? id)
        {
            ViewBag.Blogs = _dbContext.Blogs.Count();
            if (id == null)
            {
                return BadRequest();
            }
            var user = await _userManager.GetUserAsync(User);
            if(user is not null)
            {
                var vm= getBlogDetailVm((int)id,user.Id);
                if (vm.Blog == null)
                {
                    return BadRequest();
                }
                return View(vm);
            }
            else
            {
                var vm = getBlogDetailVm((int)id);
                if(vm.Blog is null)
                {
                    return BadRequest();
                }
                return View(vm);
            }
        }

        public async Task<IActionResult> AddComment(BlogComment comment)
        {
            if (!_dbContext.Blogs.Any(b=>b.Id==comment.BlogId))
            {
                return RedirectToAction("notfound", "error");
            }

            var user=await _userManager.GetUserAsync(User);

            if (user == null || !await _userManager.IsInRoleAsync(user, "Member"))
            {
                var returnUrl = Url.Action("Detail", "Blog", new { id = comment.Blog?.Id}) ?? "/";
                return RedirectToAction("Login", "Account", returnUrl);
            }

            var blogVm=getBlogDetailVm(comment.BlogId,user.Id);

            blogVm.BlogComment = comment;

            comment.AppUserId = user.Id;

            _dbContext.BlogsComment.Add(comment);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Detail", new { id = comment.BlogId });
        }
        public IActionResult BlogList()
        {
            var blogs = _dbContext.Blogs.Include(b => b.BlogImages).ToList();
            return View(blogs);
        }
    }
}
