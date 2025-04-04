using BookingTickets.Business.Dtos.VenueDtos;
using BookingTickets.Business.Dtos.VenueSeatDto;
using BookingTickets.Business.Services.Abstractions.Generic;

namespace BookingTickets.Business.Services.Abstractions;

public interface IVenueSeatService:IService<VenueSeatCreateDto,VenueSeatUpdateDto,VenueSeatReturnDto>
{
}
