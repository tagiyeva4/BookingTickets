using BookingTickets.DataAccess.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTickets.Business.Services.Implementations
{
   public class LayoutServices
    {
        private readonly BookingTicketsDbContext _dbContext;

        public LayoutServices(BookingTicketsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Dictionary<string, string> GetSettings()
        {
            return _dbContext.Settings.ToDictionary(s => s.Key, s => s.Value);
        }
    }
}
