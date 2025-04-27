using BookingTickets.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace BookingTickets.Business.Dtos.EventDtos;

public class EventReturnDto : IDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Name cannot be empty..")]
    public string Name { get; set; } = null!;
    [Required(ErrorMessage = "Description cannot be empty..")]
    public string Description { get; set; } = null!;
    public List<ScheduleDtoInEvent> Schedules { get; set; } = [];
    public int AgeRestriction { get; set; }
    public int MaxPrice { get; set; }
    public int MinPrice { get; set; }
    [Required(ErrorMessage = "PhoneNumber cannot be empty..")]
    public string PhoneNumber { get; set; } = null!;
    public List<LanguageDtoInEvent> EventLanguages { get; set; } = [];
    public List<PersonDtoInEvent> EventPersons { get; set; } = [];
    public List<string> EventImages { get; set; } = [];
    public bool IsAccess { get; set; }
    public VenueDtoInEvent Venue { get; set; } = null!;
    public int TotalTickets { get; set; }
}


public class ScheduleDtoInEvent
{
    public DateTime Date { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}

public class LanguageDtoInEvent
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}

public class PersonDtoInEvent
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
}

public class VenueDtoInEvent
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}
