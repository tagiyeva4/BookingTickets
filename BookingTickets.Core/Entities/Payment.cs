﻿using BookingTickets.Core.Enums;

namespace BookingTickets.Core.Entities;

public class Payment : BaseAuditableEntity
{
    public Order Order { get; set; } = null!;
    public int OrderId { get; set; }
    public int ReceptId { get; set; }
    public string SecretId { get; set; } = null!;
    public PaymentStatuses PaymentStatus { get; set; }
    public decimal Amount { get; set; }
    public string? Description { get; set; }
    public string Token { get; set; }
}
