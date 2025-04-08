namespace BookingTickets.Core.ViewModels;

public class CheckOutVm
{
    public List<CheckoutItemVm> CheckoutItemVms { get; set; }=new();
    public OrderVm OrderVm { get; set; }
}
