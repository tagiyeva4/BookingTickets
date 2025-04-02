using BookingTickets.Core.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingTickets.Core.Entities;

public class Event : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int AgeRestriction { get; set; }
    public string PhoneNumber { get; set; } = null!;
    public ICollection<EventLanguage> EventLanguages { get; set; } = [];
    public bool IsAccess { get; set; } = false;
    public int VenueId { get; set; }
    public Venue Venue { get; set; }
    public List<EventImage> EventImages { get; set; } = [];
    public ICollection<EventPeron> EventPersons { get; set; } = [];
    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "MaxPrice must be a positive number.")]
    public int MaxPrice { get; set; }
    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "MinPrice must be a positive number.")]
    public int MinPrice { get; set; }
    public int TotalTickets { get; set; }
    public ICollection<EventsSchedule> EventsSchedules { get; set; } = [];
    public List<Ticket> Tickets { get; set; } = [];
}
