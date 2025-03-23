using AutoMapper;
using BookingTickets.Business.Dtos.CategoryDtos;
using BookingTickets.Business.Exceptions;
using BookingTickets.Business.Services.Abstractions;
using BookingTickets.Core.Entities;
using BookingTickets.DataAccess.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookingTickets.Business.Services.Implementations;

public class CategoryService : ICategoryService
{
   private ICategoryRepository _repository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<bool> CreateAsync(CategoryCreateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
        {
            return false;
        }

        var isExist= await _repository.IsExistAsync(x=>x.Name == dto.Name);

        if (isExist)
        {
            throw new CustomException("400", "Category already exist");
        }

        var category = _mapper.Map<Category>(dto);

        await _repository.AddAsync(category);

        return true;
    }

    public async Task DeleteAsync(int id)
    {
        var category = await _repository.FindOneAsync(x => x.Id == id);

        if (category == null)
        {
            throw new CustomException(404, "Category not found");
        }

        await _repository.DeleteAsync(category);
    }

    public async Task<List<CategoryReturnDto>> GetAllAsync()
    {
        var category = await _repository.GetAllAsync();

        var dtos = _mapper.Map<List<CategoryReturnDto>>(category);

        return dtos;
    }

    public async Task<CategoryReturnDto> GetAsync(int id)
    {
        var category = await _repository.FindOneAsync(x => x.Id == id);

        if (category == null)
        {
            throw new CustomException(404, "Category not found");
        }

        var dto = _mapper.Map<CategoryReturnDto>(category);

        return dto;
    }

    public async Task<CategoryUpdateDto> GetUpdatedDtoAsync(int id)
    {
        var category = await _repository.FindOneAsync(x => x.Id == id);

        if (category == null)
        {
            throw new CustomException(404, "Category not found");
        }

        var dto = _mapper.Map<CategoryUpdateDto>(category);

        return dto;
    }

    public async Task<bool> UpdateAsync(CategoryUpdateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
        {
            return false;
        }

        var isExist = await _repository.IsExistAsync(x => x.Id!=dto.Id && x.Name == dto.Name);

        if (isExist)
        {
            throw new CustomException("400", "Category already exist");
        }

        var existCategory = await _repository.FindOneAsync(x => x.Id == dto.Id);

        if (existCategory == null)
        {
            throw new CustomException(404, "Category not found");
        }

        existCategory = _mapper.Map(dto, existCategory);

        await _repository.UpdateAsync(existCategory);

        return true;
    }

   
    public async Task<bool> IsExistAsync(int id)
    {
        var isExist = await _repository.IsExistAsync(x => x.Id == id);

        return isExist;
    }
}
