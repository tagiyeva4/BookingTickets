namespace BookingTickets.Business.Exceptions;

public interface IBaseException
{
    int StatusCode { get; }
}