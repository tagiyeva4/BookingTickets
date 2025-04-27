using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace BookingTickets.Business.Services.Implementations;

//public class RedisService
//{
//    private readonly StackExchange.Redis.IDatabase _database;

//    public RedisService(IConfiguration configuration)
//    {
//        var redis = ConnectionMultiplexer.Connect(configuration["Redis:ConnectionString"]);
//        _database = redis.GetDatabase();
//    }

//    public async Task<bool> ReserveSeatAsync(string seatKey, string userId, TimeSpan expiry)
//    {
//        return await _database.StringSetAsync(
//            seatKey,
//            userId,
//            expiry,
//            when: When.NotExists 
//        );
//    }

//    public async Task<string?> GetSeatReservationAsync(string seatKey)
//    {
//        var result = await _database.StringGetAsync(seatKey);
//        return result.HasValue ? result.ToString() : null;
//    }

//    public async Task<bool> ReleaseSeatAsync(string seatKey)
//    {
//        return await _database.KeyDeleteAsync(seatKey);
//    }
//}
