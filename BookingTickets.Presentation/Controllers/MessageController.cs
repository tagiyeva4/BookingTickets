using BookingTickets.Business.Hubs;
using BookingTickets.Core.Entities;
using BookingTickets.DataAccess.Data.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BookingTickets.Presentation.Controllers
{
    public class MessageController(UserManager<AppUser> _userManager,BookingTicketsDbContext _context,IHubContext<ChatHub> _hubContext) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";

            var user=await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            var chats=await _context.Chats.Where(x=>x.AppUserChats.Any(x=>x.AppUserId==user.Id)).ToListAsync(); 
            

            return View(chats);
        }

        [Authorize]
        public async Task<IActionResult> Detail(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return BadRequest();
            }

            var chat = await _context.Chats
                .Include(x=>x.AppUserChats)
                .ThenInclude(x=>x.AppUser)
                .Include(x => x.Messages)
                .FirstOrDefaultAsync(x => x.Id == id 
                && x.AppUserChats.Any(x=>x.AppUserId==userId));

            if (chat is null)
            {
                return NotFound();
            }

            return View(chat);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendMessage(int chatId, string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return BadRequest("Mesaj boş ola bilməz.");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return BadRequest("İstifadəçi tapılmadı.");
            }

            var chat = await _context.Chats
                .Include(c => c.AppUserChats)
                .ThenInclude(c => c.AppUser)
                .Include(c => c.Messages)
                .FirstOrDefaultAsync(c => c.Id == chatId && c.AppUserChats.Any(c => c.AppUserId == userId));

            if (chat == null)
            {
                return NotFound("Bu chat-a giriş icazəniz yoxdur.");
            }

            var message = new Message
            {
                Text = text.Trim(),
                SenderId = userId,
                ChatId = chatId,
                CreatedDate = DateTime.Now
            };

            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();

            message.Chat = null;

            foreach (var appUserChat in chat.AppUserChats.Where(x => x.AppUserId != userId))
            {
                var connectionDto = ChatHub.Connections.FirstOrDefault(x => x.UserId == appUserChat.AppUserId);
                foreach (var connection in connectionDto?.ConnectionIds ?? [])
                {
                    await _hubContext.Clients.Client(connection).SendAsync("ReceiveMessage", new
                    {
                        Text = message.Text,
                        SenderId = message.SenderId,
                        CreatedDate = message.CreatedDate?.ToString("yyyy-MM-dd HH:mm:ss")
                    });
                }
            }

            return Ok(new
            {
                Text = message.Text,
                SenderId = message.SenderId,
                CreatedDate = message.CreatedDate?.ToString("yyyy-MM-dd HH:mm:ss")
            });
        }


    }
}
