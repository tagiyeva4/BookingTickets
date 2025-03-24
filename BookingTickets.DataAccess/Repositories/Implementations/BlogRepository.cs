using BookingTickets.DataAccess.Data.Contexts;
using BookingTickets.DataAccess.Repositories.Abstractions;
using BookingTickets.DataAccess.Repositories.Implementations.Generic;

namespace BookingTickets.DataAccess.Repositories.Implementations;

public class BlogRepository : Repository<Blog>, IBlogRepository
{
    public BlogRepository(BookingTicketsDbContext dbContext) : base(dbContext)
    {
    }
}
