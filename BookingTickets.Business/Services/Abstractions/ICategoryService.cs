using BookingTickets.Business.Dtos.CategoryDtos;
using BookingTickets.Business.Services.Abstractions.Generic;

namespace BookingTickets.Business.Services.Abstractions;

public interface ICategoryService : IService<CategoryCreateDto, CategoryUpdateDto, CategoryReturnDto>
{
    Task<bool> IsExistAsync(int id);
}
