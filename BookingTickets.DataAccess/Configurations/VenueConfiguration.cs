using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingTickets.DataAccess.Configurations;

internal class VenueConfiguration : IEntityTypeConfiguration<Venue>
{
    public void Configure(EntityTypeBuilder<Venue> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasMaxLength(40);
        builder.Property(x => x.Address).IsRequired().HasMaxLength(100);
    }
}
