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
        return services;
    }
    private static void _addRepositories(IServiceCollection services)
    {
        services.AddScoped<ISliderRepository, SliderRepository>();
        services.AddScoped<IBlogRepository, BlogRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IVenueRepository, VenueRepository>();
        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<IVenueSeatRepository, VenueSeatRepository>();
        services.AddScoped<IPaymentRepository,PaymentRepository>();
        services.AddScoped<ISubscriberRepository, SubscriberRepository>();
    }
   

}
