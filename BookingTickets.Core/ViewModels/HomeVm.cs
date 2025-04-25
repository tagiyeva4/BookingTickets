using BookingTickets.Core.Entities;

namespace BookingTickets.Presentation.ViewModels
{
    public class HomeVm
    {
        public List<Slider> Sliders { get; set; }
        public List<SlidingText> SlidingTexts { get; set; }
        public List<Brands> Brands { get; set; }
        public List<Event> Events { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Person> Persons { get; set; }
    }
}
