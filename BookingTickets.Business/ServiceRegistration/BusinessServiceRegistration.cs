
using BookingTickets.Business.AutoMappers;
using BookingTickets.Business.Services.Abstractions;
using BookingTickets.Business.Services.Implementations;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using BookingTickets.Business.Dtos.EventDtos;
using BookingTickets.Business.Validators.BlogValidators;
using BookingTickets.Business.Services;

namespace BookingTickets.Business.ServiceRegistration;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(SliderAutoMapper));
        services.AddAutoMapper(typeof(BlogAutoMapper));
        services.AddAutoMapper(typeof(TagAutoMapper));
        services.AddAutoMapper(typeof(CategoryAutoMapper));
        services.AddAutoMapper(typeof(VenueAutoMapper));
        services.AddAutoMapper(typeof(EventAutoMapper));
        services.AddAutoMapper(typeof(EventScheduleAutoMapper));
        services.AddAutoMapper(typeof(PersonAutoMapper));
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining(typeof(BlogCreateDtoValidator));
        AddServices(services);
        return services; 
    }
    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<ISliderService, SliderService>();
        services.AddScoped<IBlogService, BlogService>();
        services.AddScoped<ITagService, TagService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IVenueService, VenueService>();
        services.AddScoped<IEventService, EventService>();
        services.AddScoped<IPersonService, PersonService>();
        services.AddScoped<IBasketService, BasketService>();
        services.AddScoped<LayoutServices>();
        services.AddScoped<EmailService>();
        services.AddScoped<QrCodeService>();
        services.AddScoped<ICloudinaryService, CloudinaryService>();
    }
 }
