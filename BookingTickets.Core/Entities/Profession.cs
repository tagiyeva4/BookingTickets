﻿namespace BookingTickets.Core.Entities;

public class Profession:BaseEntity
{
    public string Name { get; set; } = null!; 
    public string? Description { get; set; }

}
