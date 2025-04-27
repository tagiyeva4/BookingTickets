using BookingTickets.Business.Dtos.HubDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace BookingTickets.Business.Hubs;

public class ChatHub:Hub
{
    public static List<ConnectionDto> Connections { get; set; } = [];
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ChatHub(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public override Task OnConnectedAsync()
    {
        var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
        if(userId is null)
        {
            throw new UnauthorizedAccessException();
        }
        var connection = Connections.FirstOrDefault(x=>x.UserId==userId);
        if (connection is { })
        {
           connection.ConnectionIds.Add(Context.ConnectionId);
        }
        else
        {
            Connections.Add(new ConnectionDto
            {
                UserId = userId,
                ConnectionIds = new List<string> { Context.ConnectionId }
            });
        }
        
        return  base.OnConnectedAsync();
    }
    public override Task OnDisconnectedAsync(Exception? exception)
    {
        var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

        Connections.RemoveAll(x => x.UserId == userId);

        return base.OnDisconnectedAsync(exception);
       
    }
    public async Task SendMessage(string connectionId,string message)
    {
        await Clients.Client(connectionId).SendAsync("SendMessage", message);
    }
}
