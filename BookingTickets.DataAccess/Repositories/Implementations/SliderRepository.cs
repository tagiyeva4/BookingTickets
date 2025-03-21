using BookingTickets.Core.Entities;
using BookingTickets.DataAccess.Data.Contexts;
using BookingTickets.DataAccess.Repositories.Abstractions;
using BookingTickets.DataAccess.Repositories.Abstractions.Generic;
using BookingTickets.DataAccess.Repositories.Implementations.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTickets.DataAccess.Repositories.Implementations
{
    public class SliderRepository : Repository<Slider>, ISliderRepository
    {
        public SliderRepository(BookingTicketsDbContext dbContext) : base(dbContext)
        {
        }
    }
}
