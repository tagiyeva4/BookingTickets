using BookingTickets.Core.Entities;
using BookingTickets.DataAccess.Data.Contexts;
using BookingTickets.DataAccess.Repositories.Abstractions;
using BookingTickets.DataAccess.Repositories.Implementations.Generic;

namespace BookingTickets.DataAccess.Repositories.Implementations;

public class SliderRepository : Repository<Slider>, ISliderRepository
{
    public SliderRepository(BookingTicketsDbContext dbContext) : base(dbContext)
    {
    }
}
