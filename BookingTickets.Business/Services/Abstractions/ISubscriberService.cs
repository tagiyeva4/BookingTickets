using BookingTickets.Business.Dtos.SubscriberEmailDtos;
using BookingTickets.Business.Services.Abstractions.Generic;

namespace BookingTickets.Business.Services.Abstractions;

public interface ISubscriberService:IService<SubscriberCreateDto, SubscriberUpdateDto, SubscriberReturnDto>
{
}
