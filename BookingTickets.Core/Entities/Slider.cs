﻿namespace BookingTickets.Core.Entities;

public class Slider:BaseEntity
{
    public string FestName { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ButtonText {  get; set; }
    public string Image { get; set; }
}
