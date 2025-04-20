using AutoMapper;
using BookingTickets.Business.Dtos.EventDtos;
using BookingTickets.Business.Dtos.VenueSeatDto;
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

        if (dto.Schedules.Count == 0)
        {
            ModelState.AddModelError("Schedules", "Schedules field cannot be empty..");
            return false;
        }

        if (!_dbContext.Venues.Any(x => x.Id == dto.VenueId))
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

        @event.Venue = await _dbContext.Venues
            .Include(v => v.Seats)
            .FirstOrDefaultAsync(v => v.Id == dto.VenueId);

        if (@event.Venue == null || @event.Venue.Seats == null || !@event.Venue.Seats.Any())
        {
            ModelState.AddModelError("VenueId", "Venue or its seats not found.");
            return false;
        }

        // ✅ Seat qiymətləri təyin et
        //foreach (var seatPrice in dto.SeatPrices)
        //{
        //    var seat = @event.Venue.Seats.FirstOrDefault(s => s.Id == seatPrice.SeatId);
        //    if (seat != null)
        //    {
        //        seat.Price = seatPrice.Price;
        //    }
        //}
        if (dto.IsManualPricing && dto.SeatPrices.Any())
        {
            foreach (var seatPrice in dto.SeatPrices)
            {
                var seat = @event.Venue.Seats.FirstOrDefault(s => s.Id == seatPrice.SeatId);
                if (seat != null)
                {
                    seat.Price = seatPrice.Price;
                }
            }
        }
        else
        {
            CalculateService.CalculateSeatPricesForEvent(@event);
        }


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
            if (!_dbContext.Languages.Any(x => x.Id == languageId))
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
            EventPeron eventPeron = new() { PersonId = personId, Event = @event };
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

    //public async Task<bool> CreateAsync(EventCreateDto dto, ModelStateDictionary ModelState)
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        return false;
    //    }


    //    if (dto.Schedules.Count == 0)
    //    {
    //        ModelState.AddModelError("Schedules", "Schedules field cannot be empty..");
    //        return false;
    //    }

    //    if (!_dbContext.Venues.Any(x => x.Id == dto.VenueId))
    //    {
    //        ModelState.AddModelError("VenueId", "There is no venue in this id...");
    //        return false;
    //    }

    //    foreach (var formFile in dto.Photos)
    //    {
    //        if (formFile.CheckSize(5 * 1024 * 1024))
    //        {
    //            ModelState.AddModelError("Photo", "The size of the image should not exceed 2 MB.");
    //            return false;
    //        }

    //        if (formFile.CheckType(["image/"]))
    //        {
    //            ModelState.AddModelError("Photo", "Enter only the image format.");
    //            return false;
    //        }
    //    }

    //    var isExist = await _repository.IsExistAsync(x => x.Name == dto.Name);

    //    if (isExist)
    //    {
    //        throw new CustomException("400", "Event already exist");
    //    }

    //    var @event = _mapper.Map<Event>(dto);

    //    @event.Venue = await _dbContext.Venues
    //   .Include(v => v.Seats)
    //.FirstOrDefaultAsync(v => v.Id == dto.VenueId);

    //    if (@event.Venue == null || @event.Venue.Seats == null || !@event.Venue.Seats.Any())
    //    {
    //        ModelState.AddModelError("VenueId", "Venue or its seats not found.");
    //        return false;
    //    }

    //    @event.EventImages = [];

    //    foreach (var file in dto.Photos)
    //    {
    //        string imagePath = await _cloudinaryService.FileCreateAsync(file);
    //        EventImage image = new() { ImagePath = imagePath, Event = @event };
    //        @event.EventImages.Add(image);
    //    }
    //    @event.EventLanguages = [];

    //    foreach (var languageId in dto.EventLanguageIds)
    //    {
    //        if (!_dbContext.Languages.Any(x => x.Id == languageId))
    //        {
    //            ModelState.AddModelError("EventLanguageIds", "There is no language in this id...");
    //            return false;
    //        }
    //        EventLanguage eventLanguage = new() { LanguageId = languageId, Event = @event };
    //        @event.EventLanguages.Add(eventLanguage);
    //    }

    //    @event.EventPersons = [];
    //    foreach (var personId in dto.EventPersonIds)
    //    {
    //        if (!_dbContext.People.Any(x => x.Id == personId))
    //        {
    //            ModelState.AddModelError("EventPersonIds", "There is no language in this id...");
    //            return false;
    //        }
    //        EventPeron eventPeron = new() { PersonId = personId, Event = @event };
    //        @event.EventPersons.Add(eventPeron);
    //    }

    //    foreach (var scheduleDto in dto.Schedules)
    //    {
    //        var schedule = new Schedule
    //        {
    //            Date = scheduleDto.Date,
    //            StartTime = scheduleDto.StartTime,
    //            EndTime = scheduleDto.EndTime
    //        };

    //        _dbContext.Schedules.Add(schedule);
    //        await _dbContext.SaveChangesAsync();

    //        @event.EventsSchedules.Add(new EventsSchedule
    //        {
    //            Event = @event,
    //            Schedule = schedule
    //        });
    //    }

    //    CalculateService.CalculateSeatPricesForEvent(@event);

    //    await _repository.AddAsync(@event);

    //    return true;
    //}

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
        var @event = await _repository.FindOneAsync(x => x.Id == id, "EventImages", "EventLanguages.Language", "EventPersons.Person", "EventsSchedules.Schedule", "Venue.Seats");

        if (@event == null)
        {
            throw new CustomException(404, "Event not found");
        }

        var dto = _mapper.Map<EventUpdateDto>(@event);

        dto.VenueSeats = @event.Venue.Seats.Select(s => new VenueSeatUpdateDto
        {
            Id = s.Id,
            SeatLabel = s.SeatLabel,
            Price = s.Price
        }).ToList();


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

        var existEvent = await _repository.FindOneAsync(x => x.Id == dto.Id,
            "EventImages", "Venue.Seats",
            "EventLanguages.Language",
            "EventPersons.Person",
            "EventsSchedules.Schedule");

        if (existEvent == null)
        {
            throw new CustomException(404, "Event not found");
        }

        var isExist = await _repository.IsExistAsync(x => x.Id != dto.Id && x.Name == dto.Name);

        if (isExist)
        {
            throw new CustomException(400, "Event already exists");
        }

        if (dto.VenueSeats != null && dto.VenueSeats.Any())
        {
            foreach (var seatDto in dto.VenueSeats)
            {
                var seat = await _dbContext.VenueSeats.FindAsync(seatDto.Id);
                if (seat != null && seat.Price != seatDto.Price)
                {
                    seat.Price = (decimal)seatDto.Price; // yalnız dəyişibsə update et
                }
            }
        }


        // 🔹 Validation for new uploaded images
        if (dto.Photos != null)
        {
            foreach (var photo in dto.Photos)
            {
                if (photo.CheckSize(5 * 1024 * 1024))
                {
                    ModelState.AddModelError("Photos", "Image size max 5MB olmalıdır.");
                    return false;
                }
                if (photo.CheckType(["image/"]))
                {
                    ModelState.AddModelError("Photos", "Yalnız şəkil formatı daxil edin.");
                    return false;
                }
            }
        }

        // 🔹 Map basic properties (Name, Description, VenueId və s.)

        // 🔹 Update EventLanguages if they are selected
        if (dto.SelectedLanguageIds.Any())
        {
            existEvent.EventLanguages.Clear();
            foreach (var langId in dto.SelectedLanguageIds)
            {
                existEvent.EventLanguages.Add(new EventLanguage { LanguageId = langId });
            }
        }

        // 🔹 Update EventPersons if they are selected
        if (dto.SelectedPersonIds.Any())
        {
            existEvent.EventPersons.Clear();
            foreach (var personId in dto.SelectedPersonIds)
            {
                existEvent.EventPersons.Add(new EventPeron { PersonId = personId });
            }
        }

        // 🔹 Handle Schedules
        var existingScheduleIds = existEvent.EventsSchedules.Select(es => es.ScheduleId).ToList();
        var updatedScheduleIds = dto.EventSchedules.Where(s => s.Id != 0).Select(s => s.Id).ToList();
        var scheduleIdsToRemove = existingScheduleIds.Except(updatedScheduleIds).ToList();

        // Remove deleted schedules
        foreach (var scheduleId in scheduleIdsToRemove)
        {
            var eventSchedule = existEvent.EventsSchedules.FirstOrDefault(es => es.ScheduleId == scheduleId);
            if (eventSchedule != null)
                existEvent.EventsSchedules.Remove(eventSchedule);
        }

        // Update existing schedules that have been modified
        foreach (var schDto in dto.EventSchedules.Where(s => s.Id != 0))
        {
            var eventSchedule = existEvent.EventsSchedules.FirstOrDefault(es => es.ScheduleId == schDto.Id);
            if (eventSchedule != null && eventSchedule.Schedule != null)
            {
                eventSchedule.Schedule.Date = schDto.Date;
                eventSchedule.Schedule.StartTime = schDto.StartTime;
                eventSchedule.Schedule.EndTime = schDto.EndTime;
                _dbContext.Schedules.Update(eventSchedule.Schedule);
            }
        }

        // Add new schedules
        foreach (var schDto in dto.EventSchedules.Where(s => s.Id == 0))
        {
            var newSchedule = new Schedule
            {
                Date = schDto.Date,
                StartTime = schDto.StartTime,
                EndTime = schDto.EndTime
            };

            await _dbContext.Schedules.AddAsync(newSchedule);
            await _dbContext.SaveChangesAsync(); // Id-lə əlavə etmək üçün

            existEvent.EventsSchedules.Add(new EventsSchedule
            {
                ScheduleId = newSchedule.Id,
                EventId = existEvent.Id
            });
        }

        // 🔹 Remove old images
        var imagesToRemove = existEvent.EventImages?.ToList() ?? new List<EventImage>();
        foreach (var image in imagesToRemove)
        {
            existEvent.EventImages.Remove(image);
            await _cloudinaryService.FileDeleteAsync(image.ImagePath);
        }

        // 🔹 Add new images
        if (dto.Photos != null && dto.Photos.Any())
        {
            foreach (var photo in dto.Photos)
            {
                string path = await _cloudinaryService.FileCreateAsync(photo);
                existEvent.EventImages.Add(new EventImage { ImagePath = path });
            }
        }

        existEvent = _mapper.Map(dto, existEvent);


        await _repository.UpdateAsync(existEvent);
        return true;
    }

}
