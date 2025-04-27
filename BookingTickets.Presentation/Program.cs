using BookingTickets.Business.Hubs;
using BookingTickets.Business.ServiceRegistration;
using BookingTickets.Business.Services.Implementations;
using BookingTickets.Core.Entities;
using BookingTickets.DataAccess;
using BookingTickets.DataAccess.Data.Contexts;
using BookingTickets.DataAccess.ServiceRegistration;
using BookingTickets.Presentation.Extensions;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Stripe;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddHttpContextAccessor();
builder.Services.AddBusinessServices();  
builder.Services.AddDataAccessServices(config);

builder.Services.Configure<StripeSettings>(config.GetSection("Stripe"));
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
.AddCookie("Cookies")
.AddGoogle(GoogleDefaults.AuthenticationScheme, options =>
{
    options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
    options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
});
builder.Services.AddHttpContextAccessor();

builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
{
    opt.Password.RequireDigit = true;
    opt.Password.RequireLowercase = true;
    opt.Password.RequireNonAlphanumeric = true;
    opt.Password.RequireUppercase = true;
    opt.Password.RequiredLength = 6;
    opt.User.RequireUniqueEmail = true;
    opt.SignIn.RequireConfirmedEmail = true;
    opt.Lockout.MaxFailedAccessAttempts = 3;
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
    opt.Lockout.AllowedForNewUsers = true;
})
.AddEntityFrameworkStores<BookingTicketsDbContext>()
.AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.Events.OnRedirectToLogin = opt.Events.OnRedirectToAccessDenied = context =>
    {
        var uri = new Uri(context.RedirectUri);
        if (context.Request.Path.Value.ToLower().StartsWith("/manage"))
        {

            context.Response.Redirect("/manage/account/login" + uri.Query);
        }
        else
        {
            context.Response.Redirect("/account/login" + uri.Query);
        }

        return Task.CompletedTask;
    };
});
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseMiddleware<GlobalExceptionHandler>();
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.MapHub<ChatHub>("/chatHub");

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

StripeConfiguration.ApiKey = app.Configuration["Stripe:SecretKey"];

app.MapStaticAssets();

app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
