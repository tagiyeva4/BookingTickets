using AutoMapper;
using BookingTickets.Business.Dtos.EventDtos;
using BookingTickets.Business.Exceptions;
using BookingTickets.Business.Services.Abstractions;
using BookingTickets.Core.Entities;
using BookingTickets.DataAccess.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookingTickets.Business.Services.Implementations;

public class EventService : IEventService
{
    private readonly IEventRepository _repository;
    private readonly IMapper _mapper;
    public EventService(IEventRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<bool> CreateAsync(EventCreateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
        {
            return false;
        }

        var isExist = await _repository.IsExistAsync(x => x.Name == dto.Name);

        if (isExist)
        {
            throw new CustomException("400", "Event already exist");
        }

        var @event = _mapper.Map<Event>(dto);

        await _repository.AddAsync(@event);

        return true;
    }

    public async Task DeleteAsync(int id)
    {
        var @event=await _repository.FindOneAsync(x=> x.Id == id);

        if (@event == null)
        {
            throw new CustomException(404, "Event not found");
        } 

        await _repository.DeleteAsync(@event);
    }

    public async Task<List<EventReturnDto>> GetAllAsync()
    {
        var @events=await _repository.GetAllAsync();

        var dtos=_mapper.Map<List<EventReturnDto>>(@events); 

        return dtos;
    }

    public async Task<EventReturnDto> GetAsync(int id)
    {
        var @event=await _repository.FindOneAsync(x=> x.Id == id);

        if (@event == null)
        {
            throw new CustomException(404, "Event not found");
        }

        var dto=_mapper.Map<EventReturnDto>(@event);

        return dto;
    }

    public async Task<EventUpdateDto> GetUpdatedDtoAsync(int id)
    {
        var @event = await _repository.FindOneAsync(x=> x.Id == id);

        if (@event == null)
        {
            throw new CustomException(404, "Event not found");
        }

        var dto = _mapper.Map<EventUpdateDto>(@event);

        return dto;
    }

    public async Task<bool> IsExistAsync(int id)
    {
        var isExist = await _repository.IsExistAsync(x => x.Id == id);

        return isExist;
    }

    public async Task<bool> UpdateAsync(EventUpdateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
        {
            return false;
        }

        var existEvent = await _repository.FindOneAsync(x => x.Id == dto.Id);

        if (existEvent == null)
        {
            throw new CustomException(404, "Event not found");
        }

        var isExist = await _repository.IsExistAsync(x => x.Id != dto.Id && x.Name == dto.Name);

        if (isExist)
        {
            throw new CustomException("400", "Event already exist");
        }

        existEvent = _mapper.Map(dto, existEvent);

        await _repository.UpdateAsync(existEvent);

        return true;
    }
}
