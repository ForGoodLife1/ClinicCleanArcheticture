using Clinic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Infrastructure.Configurations
{
    public class MedicalRecordConfigurations : IEntityTypeConfiguration<MedicalRecord>
    {
        public void Configure(EntityTypeBuilder<MedicalRecord> builder)
        {
            builder.HasKey(e => e.MedicalRecordId).HasName("PK__MedicalR__4411BBC251D4E64A");

            builder.Property(e => e.MedicalRecordId)
                .ValueGeneratedNever()
                .HasColumnName("MedicalRecordID");
            builder.Property(e => e.AdditionalNotes).HasMaxLength(200);
            builder.Property(e => e.Diagnosis).HasMaxLength(200);
            builder.Property(e => e.VisitDescription).HasMaxLength(200);

        }
    }
}
