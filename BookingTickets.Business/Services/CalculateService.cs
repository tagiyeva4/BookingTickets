using BookingTickets.Core.Entities;

namespace BookingTickets.Business.Services;

public static class CalculateService
{
    public static void CalculateSeatPricesForEvent(Event @event)
    {
        var seats = @event.Venue.Seats.ToList();

        int rowCount = seats.Select(s => s.RowNumber).Distinct().Count();

        foreach (var seat in seats)
        {
            if (rowCount <= 1)
            {
                seat.Price = Convert.ToInt32(@event.MaxPrice);
            }
            else if (seat.RowNumber == 1)
            {
                seat.Price = Convert.ToInt32(@event.MaxPrice);
            }
            else if (seat.RowNumber == rowCount)
            {
                seat.Price = Convert.ToInt32(@event.MinPrice);
            }
            else
            {
                decimal priceRange = @event.MaxPrice - @event.MinPrice;
                decimal priceStep = priceRange / (rowCount - 1);
                decimal discount = (seat.RowNumber - 1) * priceStep;

                seat.Price = Math.Round(@event.MaxPrice - discount, 0); 
            }
        }
    }

}
