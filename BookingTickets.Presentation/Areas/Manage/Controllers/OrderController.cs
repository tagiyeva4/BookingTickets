using BookingTickets.Business.Helpers;
using BookingTickets.Core.Entities;
using BookingTickets.DataAccess.Data.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.Presentation.Areas.Manage.Controllers;

[Area("Manage")]
[Authorize(Roles = "Admin")]
public class OrderController(BookingTicketsDbContext dbContext) : Controller
{
    public IActionResult Index(int page = 1, int pageSize = 10)
    {
        var query = dbContext.Orders
            .Include(x => x.AppUser)
            .Include(x => x.OrderItems)
                .ThenInclude(x => x.Ticket)
            .OrderByDescending(x => x.CreatedDate)
            .AsQueryable();

        var paginatedOrders = PaginatedList<Order>.Create(query, page, pageSize);

        return View(paginatedOrders);
    }



}
