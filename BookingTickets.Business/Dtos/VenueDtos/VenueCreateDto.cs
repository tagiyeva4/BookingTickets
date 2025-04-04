using BookingTickets.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace BookingTickets.Business.Dtos.VenueDtos;

public class VenueCreateDto:IDto
{
    [Required(ErrorMessage = "Name field cannot be empty..")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Address field cannot be empty..")]
    public string Address { get; set; } = null!;

    [Required(ErrorMessage = "Latitude field cannot be empty..")]
    [Range(-90, 90)]
    public double Latitude { get; set; }

    [Required(ErrorMessage = "Longitude field cannot be empty..")]
    [Range(-180, 180)]
    public double Longitude { get; set; }

    [Required(ErrorMessage = "Number of rows cannot be empty")]
    [Range(1, 100, ErrorMessage = "Number of rows must be between 1 and 100")]
    public int NumberOfRows { get; set; }

    [Required(ErrorMessage = "Seats per row cannot be empty")]
    [Range(1, 100, ErrorMessage = "Seats per row must be between 1 and 100")]
    public int SeatsPerRow { get; set; }
    public RowNamingStyle RowNamingStyle { get; set; } = RowNamingStyle.Numeric;
}
