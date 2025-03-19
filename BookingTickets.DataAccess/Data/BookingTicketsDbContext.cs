using BookingTickets.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.DataAccess.Data
{
    public class BookingTicketsDbContext : IdentityDbContext<AppUser>
    {
        public BookingTicketsDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Service>Services { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SlidingText> SlidingTexts { get; set; }
        public DbSet<Brands> Brands { get; set; }
        
    }
}
