using AutoMapper;
using BookingTickets.Business.Dtos.EventDtos;
using BookingTickets.Business.Exceptions;
using BookingTickets.Business.Helpers;
using BookingTickets.Business.Services.Abstractions;
using BookingTickets.Core.Entities;
using BookingTickets.DataAccess.Data.Contexts;
using BookingTickets.DataAccess.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.Business.Services.Implementations;

public class EventService : IEventService
{
    private readonly IEventRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICloudinaryService _cloudinaryService;
    private readonly BookingTicketsDbContext _dbContext;
    public EventService(IEventRepository repository, IMapper mapper, ICloudinaryService cloudinaryService, BookingTicketsDbContext dbContext)
    {
        _repository = repository;
        _mapper = mapper;
        _cloudinaryService = cloudinaryService;
        _dbContext = dbContext;
    }

    public async Task<bool> CreateAsync(EventCreateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
        {
            return false;
        }

        if(!_dbContext.Venues.Any(x => x.Id == dto.VenueId))
        {
            ModelState.AddModelError("VenueId", "There is no venue in this id...");
            return false;
        }

        foreach (var formFile in dto.Photos)
        {
            if (formFile.CheckSize(5 * 1024 * 1024))
            {
                ModelState.AddModelError("Photo", "The size of the image should not exceed 2 MB.");
                return false;
            }

            if (formFile.CheckType(["image/"]))
            {
                ModelState.AddModelError("Photo", "Enter only the image format.");
                return false;
            }
        }

        var isExist = await _repository.IsExistAsync(x => x.Name == dto.Name);

        if (isExist)
        {
            throw new CustomException("400", "Event already exist");
        }

        var @event = _mapper.Map<Event>(dto);

        @event.EventImages = [];

        foreach (var file in dto.Photos)
        {
            string imagePath = await _cloudinaryService.FileCreateAsync(file);
            EventImage image = new() { ImagePath = imagePath, Event = @event };
            @event.EventImages.Add(image);
        }
        @event.EventLanguages = [];

        foreach (var languageId in dto.EventLanguageIds)
        {
            if(!_dbContext.Languages.Any(x => x.Id == languageId))
            {
                ModelState.AddModelError("EventLanguageIds", "There is no language in this id...");
                return false;
            }
            EventLanguage eventLanguage = new() { LanguageId = languageId, Event = @event };
            @event.EventLanguages.Add(eventLanguage);
        }

        @event.EventPersons = [];
        foreach (var personId in dto.EventPersonIds)
        {
            if (!_dbContext.People.Any(x => x.Id == personId))
            {
                ModelState.AddModelError("EventPersonIds", "There is no language in this id...");
                return false;
            }
            EventPeron eventPeron= new() { PersonId = personId, Event = @event };
            @event.EventPersons.Add(eventPeron);
        }

        foreach (var scheduleDto in dto.Schedules)
        {
            var schedule = new Schedule
            {
                Date = scheduleDto.Date,
                StartTime = scheduleDto.StartTime,
                EndTime = scheduleDto.EndTime
            };

            _dbContext.Schedules.Add(schedule);
            await _dbContext.SaveChangesAsync();

            @event.EventsSchedules.Add(new EventsSchedule
            {
                Event = @event,
                Schedule = schedule
            });
        }

        await _repository.AddAsync(@event);

        return true;
    }

    public async Task DeleteAsync(int id)
    {
        var @event = await _repository.FindOneAsync(x => x.Id == id, "EventImages", "EventLanguages", "EventPersons");

        if (@event == null)
        {
            throw new CustomException(404, "Event not found");
        }

        await _repository.DeleteAsync(@event);
    }

    public async Task<List<EventReturnDto>> GetAllAsync()
    {
        var @events = await _repository.GetAllAsync("EventImages", "EventLanguages.Language");

        var dtos = _mapper.Map<List<EventReturnDto>>(@events);

        return dtos;
    }

    public async Task<EventReturnDto> GetAsync(int id)
    {
        var @event = await _repository.FindOneAsync(x => x.Id == id, "EventImages", "Venue", "EventLanguages.Language", "EventPersons.Person");

        if (@event == null)
        {
            throw new CustomException(404, "Event not found");
        }

        var dto = _mapper.Map<EventReturnDto>(@event);

        return dto;
    }

    public async Task<EventUpdateDto> GetUpdatedDtoAsync(int id)
    {
        var @event = await _repository.FindOneAsync(x => x.Id == id, "EventImages", "Venue","EventLanguages.Language", "EventPersons.Person");

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

        var existEvent = await _repository.FindOneAsync(x => x.Id == dto.Id, "EventImages", "Venue", "EventLanguages.Language","EventPersons.Person");

        if (existEvent == null)
        {
            throw new CustomException(404, "Event not found");
        }

        var isExist = await _repository.IsExistAsync(x => x.Id != dto.Id && x.Name == dto.Name);

        if (isExist)
        {
            throw new CustomException("400", "Event already exist");
        }

        if (dto.Photos != null)
        {
            foreach (var formFile in dto.Photos)
            {
                if (formFile.CheckSize(5 * 1024 * 1024))
                {
                    ModelState.AddModelError("Photos", "The size of the image should not exceed 2 MB.");
                    return false;
                }

                if (formFile.CheckType(["image/"]))
                {
                    ModelState.AddModelError("Photos", "Enter only the image format.");
                    return false;
                }
            }
        }

        existEvent = _mapper.Map(dto, existEvent);



        //remove deletedImages
        var imagesToRemove = existEvent.EventImages?.ToList() ?? new List<EventImage>();

        foreach (var image in imagesToRemove)
        {
            existEvent.EventImages.Remove(image);
            await _cloudinaryService.FileDeleteAsync(image.ImagePath);
        }
        //add newImages
        if (dto.Photos != null && dto.Photos.Any())
        {
            foreach (var newImage in dto.Photos)
            {
                string newImagePath = await _cloudinaryService.FileCreateAsync(newImage);
                EventImage eventImage = new() { ImagePath = newImagePath };
                existEvent.EventImages.Add(eventImage);
            }
        }


        
        //var existingSchedules =existEvent.EventsSchedules.ToList();

        //foreach (var scheduleDto in dto.Schedules)
        //{
        //    var existingSchedule = existingSchedules.FirstOrDefault(s => s.ScheduleId == scheduleDto.Id);

        //    if (existingSchedule != null)
        //    {
        //        if (existingSchedule.Schedule.Date == scheduleDto.Date &&
        //            existingSchedule.Schedule.StartTime == scheduleDto.StartTime &&
        //            existingSchedule.Schedule.EndTime == scheduleDto.EndTime)
        //        {
        //            continue;
        //        }

        //        existingSchedule.Schedule.Date = scheduleDto.Date;
        //        existingSchedule.Schedule.StartTime = scheduleDto.StartTime;
        //        existingSchedule.Schedule.EndTime = scheduleDto.EndTime;
        //    }
        //    else
        //    {
        //        var newSchedule = new Schedule
        //        {
        //            Date = scheduleDto.Date,
        //            StartTime = scheduleDto.StartTime,
        //            EndTime = scheduleDto.EndTime
        //        };
        //        _dbContext.Schedules.Add(newSchedule);
        //        await _dbContext.SaveChangesAsync(); 

        //        existEvent.EventsSchedules.Add(new EventsSchedule
        //        {
        //            EventId = existEvent.Id,
        //            ScheduleId = newSchedule.Id
        //        });
        //    }
        //}


        await _repository.UpdateAsync(existEvent);

        return true;
    }
}
