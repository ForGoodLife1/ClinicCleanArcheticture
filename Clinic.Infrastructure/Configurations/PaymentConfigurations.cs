using Clinic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Infrastructure.Configurations
{
    public class PaymentConfigurations : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(e => e.PaymentId).HasName("PK__Payments__9B556A585488506C");

            builder.Property(e => e.PaymentId)
                .ValueGeneratedNever()
                .HasColumnName("PaymentID");
            builder.Property(e => e.AdditionalNotes).HasMaxLength(200);
            builder.Property(e => e.AmountPaid).HasColumnType("decimal(18, 0)");
            builder.Property(e => e.PaymentMethod).HasMaxLength(50);
        }
    }
}
