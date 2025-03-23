using BookingTickets.Business.Dtos.BlogDtos;
using BookingTickets.Business.Services.Abstractions.Generic;

namespace BookingTickets.Business.Services.Abstractions;

public interface IBlogService:IService<BlogCreateDto,BlogUpdateDto,BlogReturnDto>
{
}
