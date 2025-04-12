namespace BookingTickets.Core.ViewModels;

public class BasketItemVm
{
    public int Id { get; set; }
    public string? Name { get; set; } 
    public decimal Price { get; set; }
    public int Count { get; set; }

    public string? EventName { get; set; }
    public string? SeatLocation { get; set; }
    public string? QRCodePath { get; set; }
    public DateTime ExpireAt { get; set; } = DateTime.UtcNow.AddMinutes(15);
}


