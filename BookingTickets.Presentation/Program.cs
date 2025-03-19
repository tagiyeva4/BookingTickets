using BookingTickets.Business.Services;
using BookingTickets.Core.Entities;
using BookingTickets.DataAccess.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var config=builder.Configuration;
builder.Services.AddDbContext<BookingTicketsDbContext>(options =>
{
    options.UseSqlServer(config["ConnectionStrings:DefaultConnection"]);
});
builder.Services.AddScoped<LayoutServices>();
builder.Services.AddScoped<EmailService>();
//builder.Services.AddAuthentication()
//                .AddGoogle(options =>
//                {
//                    options.ClientId = "748514526525-qpbosdvbv58ivo0a1cklh8n2826sqglu.apps.googleusercontent.com";
//                    options.ClientSecret = "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";
//                    options.SaveTokens = true;
//                });
//builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
//{
//    opt.Password.RequireDigit = true;
//    opt.Password.RequireLowercase = true;
//    opt.Password.RequireNonAlphanumeric = true;
//    opt.Password.RequireUppercase = true;
//    opt.Password.RequiredLength = 6;

//    opt.User.RequireUniqueEmail = true;
//    opt.SignIn.RequireConfirmedEmail = true;
//    opt.Lockout.MaxFailedAccessAttempts = 3;
//    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
//    opt.Lockout.AllowedForNewUsers = true;
//}).AddEntityFrameworkStores<BookingTicketsDbContext>().AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
