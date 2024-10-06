using Clinic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Infrastructure.Configurations
{
    public class AppointmentConfigurations : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(e => e.AppointmentId).HasName("PK__Appointm__8ECDFCA2896563A4");

            builder.Property(e => e.AppointmentId)
                .ValueGeneratedNever()
                .HasColumnName("AppointmentID");
            builder.Property(e => e.AppointmentDateTime).HasColumnType("datetime");
            builder.Property(e => e.DoctorId).HasColumnName("DoctorID");
            builder.Property(e => e.MedicalRecordId).HasColumnName("MedicalRecordID");
            builder.Property(e => e.PatientId).HasColumnName("PatientID");
            builder.Property(e => e.PaymentId).HasColumnName("PaymentID");

            builder.HasOne(d => d.Doctor).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointments.DoctorID");

            builder.HasOne(d => d.MedicalRecord).WithMany(p => p.Appointments)
                 .HasForeignKey(d => d.MedicalRecordId)
                 .HasConstraintName("FK_Appointments_MedicalRecords");

            builder.HasOne(d => d.Patient).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointments.PatientID");

            builder.HasOne(d => d.Payment).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PaymentId)
                .HasConstraintName("FK_Payments.PaymentID");

        }
    }
}
