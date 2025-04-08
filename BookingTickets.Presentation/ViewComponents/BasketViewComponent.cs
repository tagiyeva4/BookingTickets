using BookingTickets.Business.Services.Abstractions;
using BookingTickets.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookingTickets.Presentation.ViewComponents
{
    public class BasketViewComponent : ViewComponent
    {
        private readonly IBasketService basketService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public BasketViewComponent(IBasketService basketService, IHttpContextAccessor httpContextAccessor)
        {
            this.basketService = basketService;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return View(new List<BasketItemVm>());

            var items = await basketService.GetUserBasketAsync(userId);
            return View(items);
        }
    }

}
