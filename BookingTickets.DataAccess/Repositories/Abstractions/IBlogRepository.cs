using BookingTickets.Core.Entities;
using BookingTickets.DataAccess.Repositories.Abstractions.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTickets.DataAccess.Repositories.Abstractions
{
    public interface  IBlogRepository:IRepository<Blog>
    {
    }
}
