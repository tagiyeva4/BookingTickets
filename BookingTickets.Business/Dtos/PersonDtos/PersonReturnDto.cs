using BookingTickets.Core.Entities;

namespace BookingTickets.Business.Dtos.PersonDtos;

public class PersonReturnDto:IDto
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public int ProfessionId { get; set; }
    public Profession Profession { get; set; } = null!;
    public ICollection<EventPeron> EventPersons { get; set; } = [];
    public string ImageUrl { get; set; } = null!;
}
