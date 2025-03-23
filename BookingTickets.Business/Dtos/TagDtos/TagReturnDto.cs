using System.ComponentModel.DataAnnotations;

namespace BookingTickets.Business.Dtos.TagDtos;

public class TagReturnDto:IDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}
