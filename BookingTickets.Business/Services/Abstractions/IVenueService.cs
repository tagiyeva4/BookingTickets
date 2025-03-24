using BookingTickets.Business.Dtos.VenueDtos;
using BookingTickets.Business.Services.Abstractions.Generic;

namespace BookingTickets.Business.Services.Abstractions;

public interface IVenueService:IService<VenueCreateDto,VenueUpdateDto,VenueReturnDto>
{
    Task<bool> IsExistAsync(int id);
}
