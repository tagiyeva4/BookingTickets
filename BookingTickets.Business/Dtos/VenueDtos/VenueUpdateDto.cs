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


//public class VenueUpdateDto : IDto
//{
//    public int Id { get; set; }

//    [Required(ErrorMessage = "Name field cannot be empty..")]
//    public string Name { get; set; } = null!;
//    public string? Address { get; set; }

//    [Range(-90, 90)]
//    public double Latitude { get; set; }

//    [Range(-180, 180)]
//    public double Longitude { get; set; }

//    public int Capacity { get; set; }
//    public int NumberOfRows { get; set; }
//    public int SeatsPerRow { get; set; }
//    public RowNamingStyle RowNamingStyle { get; set; }
//}


