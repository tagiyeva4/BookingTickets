namespace BookingTickets.Business.Dtos.EventScheduleDtos;

public class EventScheduleCreateDto:IDto
{
    public DateTime Date { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}
