using BookingTickets.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace BookingTickets.Business.Dtos.VenueDtos;


public class VenueUpdateDto:IDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; } 

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    [Range(1, 100, ErrorMessage = "Sıra sayı 1-100 arasında olmalıdır")]
    public int NumberOfRows { get; set; }

    [Range(1, 100, ErrorMessage = "Hər sırada oturacaq sayı 1-100 arasında olmalıdır")]
    public int SeatsPerRow { get; set; }

    public RowNamingStyle RowNamingStyle { get; set; }
}


