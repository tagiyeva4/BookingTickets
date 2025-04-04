using BookingTickets.DataAccess.Data.Contexts;
using BookingTickets.DataAccess.Repositories.Abstractions;
using BookingTickets.DataAccess.Repositories.Implementations.Generic;

namespace BookingTickets.DataAccess.Repositories.Implementations
{
    public class VenueSeatRepository:Repository<VenueSeat>, IVenueSeatRepository
    {
        public VenueSeatRepository(BookingTicketsDbContext dbContext) : base(dbContext)
        {
        }
    }
    
}
