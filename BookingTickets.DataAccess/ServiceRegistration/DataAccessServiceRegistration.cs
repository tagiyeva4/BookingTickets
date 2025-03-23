using BookingTickets.DataAccess.Data.Contexts;
using BookingTickets.DataAccess.Repositories.Abstractions;
using BookingTickets.DataAccess.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace BookingTickets.DataAccess.ServiceRegistration;

public static class DataAccessServiceRegistration
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BookingTicketsDbContext>(options =>
        {
            options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
        });
        _addRepositories(services);
        //_addIdentity(services);
        return services;
    }
    private static void _addRepositories(IServiceCollection services)
    {
        services.AddScoped<ISliderRepository, SliderRepository>();
        services.AddScoped<IBlogRepository, BlogRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
    }
    //private static void _addIdentity(IServiceCollection services)
    //{
    //    services.AddIdentity<AppUser, IdentityRole>(opt =>
    //    {
    //        opt.Password.RequireDigit = true;
    //        opt.Password.RequireLowercase = true;
    //        opt.Password.RequireNonAlphanumeric = true;
    //        opt.Password.RequireUppercase = true;
    //        opt.Password.RequiredLength = 6;
    //        opt.User.RequireUniqueEmail = true;
    //        opt.SignIn.RequireConfirmedEmail = true;
    //        opt.Lockout.MaxFailedAccessAttempts = 3;
    //        opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
    //        opt.Lockout.AllowedForNewUsers = true;
    //    }).AddEntityFrameworkStores<BookingTicketsDbContext>().AddDefaultTokenProviders();

    //}

}
