﻿using System.ComponentModel.DataAnnotations;

namespace BookingTickets.Core.Entities;

public class Setting
{
    [Key]
    public string Key { get; set; }
    public string Value { get; set; }
}
