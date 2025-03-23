namespace BookingTickets.Business.Dtos.SliderDtos;

public class SliderReturnDto:IDto
{
    public int Id { get; set; }
    public string FestName { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ButtonText { get; set; } = null!;
    public string Image { get; set; } = null!;

}
