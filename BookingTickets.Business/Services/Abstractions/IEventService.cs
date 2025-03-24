using BookingTickets.Business.Dtos.EventDtos;
using BookingTickets.Business.Services.Abstractions.Generic;

namespace BookingTickets.Business.Services.Abstractions;

public interface IEventService:IService<EventCreateDto,EventUpdateDto,EventReturnDto>
{
    Task<bool> IsExistAsync(int id);
}
