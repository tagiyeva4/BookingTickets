using BookingTickets.Business.Dtos.BlogDtos;
using BookingTickets.Business.Services.Abstractions.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTickets.Business.Services.Abstractions
{
   public interface IBlogService:IService<BlogCreateDto,BlogUpdateDto,BlogReturnDto>
    {
    }
}
