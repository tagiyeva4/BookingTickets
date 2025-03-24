namespace BookingTickets.Business.Dtos.EventDtos;

public class EventReturnDto:IDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public List<DateTime> Dates { get; set; } = [];
    public int AgeRestriction { get; set; }
    public string PhoneNumber { get; set; } = null!;
    public List<LanguageDtoInEvent> EventLanguages { get; set; } = [];
    public bool IsAccess { get; set; }
    public VenueDtoInEvent Venue { get; set; } = null!;
}
public class VenueDtoInEvent
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public int Capacity { get; set; }
}

public class LanguageDtoInEvent
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
}
