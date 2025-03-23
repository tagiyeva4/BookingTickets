namespace BookingTickets.Business.Dtos.CategoryDtos;

public class CategoryReturnDto:IDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}
