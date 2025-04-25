using BookingTickets.Core.Entities;

namespace BookingTickets.Core.ViewModels;

public class ServiceVm
{
    public List<Service> Services { get; set; } = new List<Service>();
    public List<Category> Categories { get; set; } = new List<Category>();
    public Service Service { get; set; } = new Service();
}
