using BookingTickets.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BookingTickets.DataAccess.Data.Contexts
{
    public class BookingTicketsDbContext : IdentityDbContext<AppUser>
    {
        public BookingTicketsDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Service>Services { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SlidingText> SlidingTexts { get; set; }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<SubscribeEmail> SubscribeEmails { get; set; }

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
