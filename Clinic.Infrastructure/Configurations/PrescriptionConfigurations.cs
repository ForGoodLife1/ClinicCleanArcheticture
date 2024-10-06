using Clinic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Infrastructure.Configurations
{
    public class PrescriptionConfigurations : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey(e => e.PrescriptionId).HasName("PK__Prescrip__40130812FF0A60CF");

            builder.Property(e => e.PrescriptionId)
                .ValueGeneratedNever()
                .HasColumnName("PrescriptionID");
            builder.Property(e => e.Dosage).HasMaxLength(50);
            builder.Property(e => e.Frequency).HasMaxLength(50);
            builder.Property(e => e.MedicalRecordId).HasColumnName("MedicalRecordID");
            builder.Property(e => e.MedicationNameAr).HasMaxLength(100);
            builder.Property(e => e.MedicationNameEn).HasMaxLength(100);
            builder.Property(e => e.SpecialInstructions).HasMaxLength(200);

            builder.HasOne(d => d.MedicalRecord).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.MedicalRecordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prescriptions.MedicalRecordID");
        }
    }
}
