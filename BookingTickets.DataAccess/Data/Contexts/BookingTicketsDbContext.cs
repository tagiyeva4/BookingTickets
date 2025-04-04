using BookingTickets.Core.Entities.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BookingTickets.DataAccess.Data.Contexts
{
    public class BookingTicketsDbContext : IdentityDbContext<AppUser>
    {
        public BookingTicketsDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Service> Services { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SlidingText> SlidingTexts { get; set; }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<SubscribeEmail> SubscribeEmails { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogImage> BlogsImage { get; set; }
        public DbSet<BlogComment> BlogsComment { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventImage> EventsImage { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<EventsSchedule> EventsSchedules { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<VenueSeat> VenueSeats { get; set; }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseAuditableEntity>();
            foreach (var entire in entries)
            {
                if (entire.State == EntityState.Added)
                {
                    entire.Property(p => p.CreatedDate).CurrentValue = DateTime.Now;
                }
                if (entire.State == EntityState.Modified)
                {
                    entire.Property(p => p.UpdatedDate).CurrentValue = DateTime.Now;
                }
                if (entire.Property(p => p.IsDeleted).CurrentValue == true)
                {
                    entire.Property(p => p.DeletedDate).CurrentValue = DateTime.Now;
                }
                if (entire.State == EntityState.Deleted)
                {
                    entire.Property(p => p.DeletedDate).CurrentValue = DateTime.Now;
                    entire.Property(p => p.IsDeleted).CurrentValue = true;
                    entire.State = EntityState.Modified;
                }
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region seedData

            var userId = Guid.NewGuid().ToString();
            var adminId = Guid.NewGuid().ToString();
            var memberId = Guid.NewGuid().ToString();
            var superAdminId = Guid.NewGuid().ToString();
            var vipmemberId = Guid.NewGuid().ToString();

            //Seeding a  'Administrator' role to AspNetRoles table
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = adminId,
                    Name = "Admin",
                    NormalizedName = "ADMIN".ToUpper()
                },
                new IdentityRole
                {
                    Id = memberId,
                    Name = "Member",
                    NormalizedName = "MEMBER".ToUpper()
                },
                new IdentityRole
                {
                    Id = superAdminId,
                    Name = "EventOrganizer",
                    NormalizedName = "EVENTORGANIZER".ToUpper()
                },
                new IdentityRole
                {
                    Id = vipmemberId,
                    Name = "VipMember",
                    NormalizedName = "VIPMEMBER".ToUpper()
                }

            );
            //a hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<IdentityUser>();

            modelBuilder.Entity<AppUser>().HasData(
           new AppUser
           {
               Id = userId, // primary key
               FullName = "Test testov",
               UserName = "_test",
               NormalizedUserName = "_TEST",
               PasswordHash = hasher.HashPassword(null, "12345@Tt")
           }
            );
            //Seeding the relation between our user and role to AspNetUserRoles table
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = memberId,
                    UserId = userId
                }
            );

            modelBuilder.Entity<Language>().HasData(
            new Language { Id = 1, Name = "Azərbaycan", Code = "az" },
            new Language { Id = 2, Name = "Türkçe", Code = "tr" },
            new Language { Id = 3, Name = "English", Code = "en" },
            new Language { Id = 4, Name = "Français", Code = "fr" },
            new Language { Id = 5, Name = "Deutsch", Code = "de" }
            );

            modelBuilder.Entity<Profession>().HasData(
       new Profession { Id = 1, Name = "Singer" },
       new Profession { Id = 2, Name = "Speaker" },
       new Profession { Id = 3, Name = "Software Developer" },
       new Profession { Id = 4, Name = "Lawyer" }
   );
            #endregion

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning)
            );
        }


    }
}
