using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingTickets.DataAccess.Configurations;

internal class LanguageConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasMaxLength(20);
        builder.Property(x => x.Code).IsRequired().HasMaxLength(5);
    }
}
