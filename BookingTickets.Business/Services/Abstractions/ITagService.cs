using BookingTickets.Business.Dtos.TagDtos;
using BookingTickets.Business.Services.Abstractions.Generic;

namespace BookingTickets.Business.Services.Abstractions;

public interface ITagService:IService<TagCreateDto, TagUpdateDto,TagReturnDto>
{
    Task<bool> IsExistAsync(int id);
}
