namespace BookingTickets.Core.Entities
{
    public class Language : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public ICollection<EventLanguage> EventLanguages { get; set; } = [];

    }
}
