namespace BookingTickets.Business.Dtos.EventScheduleDtos;

public class EventScheduleReturnDto:IDto
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}
