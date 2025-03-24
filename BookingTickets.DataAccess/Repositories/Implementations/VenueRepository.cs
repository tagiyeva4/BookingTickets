using BookingTickets.DataAccess.Data.Contexts;
using BookingTickets.DataAccess.Repositories.Abstractions;
using BookingTickets.DataAccess.Repositories.Implementations.Generic;

namespace BookingTickets.DataAccess.Repositories.Implementations;

public class VenueRepository : Repository<Venue>, IVenueRepository
{
    public VenueRepository(BookingTicketsDbContext dbContext) : base(dbContext)
    {
    }
}
