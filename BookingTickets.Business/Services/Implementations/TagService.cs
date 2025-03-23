using AutoMapper;
using BookingTickets.Business.Dtos.TagDtos;
using BookingTickets.Business.Exceptions;
using BookingTickets.Business.Services.Abstractions;
using BookingTickets.Core.Entities;
using BookingTickets.DataAccess.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookingTickets.Business.Services.Implementations;

public class TagService : ITagService
{
    private ITagRepository _repository;
    private readonly IMapper _mapper;
    public TagService(ITagRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<bool> CreateAsync(TagCreateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
        {
            return false;
        }

        var isExist = await _repository.IsExistAsync(x => x.Name == dto.Name);

        if (isExist)
        {
            throw new CustomException("400", "Category already exist");
        }

        var tag = _mapper.Map<Tag>(dto);

        await _repository.AddAsync(tag);

        return true;
    }

    public async Task<bool> UpdateAsync(TagUpdateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
        {
            return false;
        }

        var existTag = await _repository.FindOneAsync(x => x.Id == dto.Id);

        if (existTag == null)
        {
            throw new CustomException(404, "Tag not found");
        }

        var isExist = await _repository.IsExistAsync(x => x.Id != dto.Id && x.Name == dto.Name);

        if (isExist)
        {
            throw new CustomException("400", "Tag already exist");
        }

        existTag = _mapper.Map(dto, existTag);

        await _repository.UpdateAsync(existTag);

        return true;
    }

    public async Task<TagUpdateDto> GetUpdatedDtoAsync(int id)
    {
        var tag = await _repository.FindOneAsync(x => x.Id == id);

        if (tag == null)
        {
            throw new CustomException(404, "Tag not found");
        }

        var dto = _mapper.Map<TagUpdateDto>(tag);

        return dto;
    }

    public async Task<List<TagReturnDto>> GetAllAsync()
    {
        var tags = await _repository.GetAllAsync();

        var dtos = _mapper.Map<List<TagReturnDto>>(tags);

        return dtos;
    }

    public async Task<TagReturnDto> GetAsync(int id)
    {
        var tag = await _repository.FindOneAsync(x => x.Id == id);

        if (tag == null)
        {
            throw new CustomException(404, "Tag not found");
        }

        var dto = _mapper.Map<TagReturnDto>(tag);

        return dto;
    }

    public async Task DeleteAsync(int id)
    {
        var tag = await _repository.FindOneAsync(x => x.Id == id);

        if (tag == null)
        {
            throw new CustomException(404, "Tag not found");
        }

        await _repository.DeleteAsync(tag);
    }
   
    public async Task<bool> IsExistAsync(int id)
    {
        var isExist = await _repository.IsExistAsync(x => x.Id == id);

        return isExist;
    }
}
