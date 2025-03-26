namespace BookingTickets.Core.Entities;

public class Person:BaseEntity
{
    public  string FullName { get; set; } = null!;
    public int ProfessionId { get; set; }   
    public Profession Profession { get; set; }
    public ICollection<EventPeron> EventPersons { get; set; } = [];
}
