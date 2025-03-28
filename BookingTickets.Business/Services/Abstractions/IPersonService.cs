using BookingTickets.Business.Dtos.PersonDtos;
using BookingTickets.Business.Services.Abstractions.Generic;

namespace BookingTickets.Business.Services.Abstractions;

public interface IPersonService: IService<PersonCreateDto, PersonUpdateDto, PersonReturnDto>
{
    Task<bool> IsExistAsync(int id);
}
