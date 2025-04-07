using BookingTickets.Business.Dtos.VenueDtos;
using BookingTickets.Business.Dtos.VenueSeatDto;
using BookingTickets.Business.Services.Abstractions.Generic;
using BookingTickets.Core.Entities;

namespace BookingTickets.Business.Services.Abstractions;

public interface IVenueSeatService:IService<VenueSeatCreateDto,VenueSeatUpdateDto,VenueSeatReturnDto>
{
    Task AddManyAsync(IEnumerable<VenueSeat> entities);
}
