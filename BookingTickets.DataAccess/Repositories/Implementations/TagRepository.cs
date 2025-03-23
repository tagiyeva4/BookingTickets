using BookingTickets.Core.Entities;
using BookingTickets.DataAccess.Data.Contexts;
using BookingTickets.DataAccess.Repositories.Abstractions;
using BookingTickets.DataAccess.Repositories.Implementations.Generic;

namespace BookingTickets.DataAccess.Repositories.Implementations;

public class TagRepository : Repository<Tag>, ITagRepository
{
    public TagRepository(BookingTicketsDbContext dbContext) : base(dbContext)
    {
    }
}
