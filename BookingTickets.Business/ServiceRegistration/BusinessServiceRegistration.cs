
using BookingTickets.Business.AutoMappers;
using BookingTickets.Business.Services.Abstractions;
using BookingTickets.Business.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace BookingTickets.Business.ServiceRegistration;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(SliderAutoMapper));
        services.AddAutoMapper(typeof(BlogAutoMapper));
        services.AddAutoMapper(typeof(TagAutoMapper));
        services.AddAutoMapper(typeof(CategoryAutoMapper));
        AddServices(services);
        return services; 
    }
    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<ISliderService, SliderService>();
        services.AddScoped<IBlogService, BlogService>();
        services.AddScoped<ITagService, TagService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<LayoutServices>();
        services.AddScoped<EmailService>();
        services.AddScoped<ICloudinaryService, CloudinaryService>();
    }
 }
