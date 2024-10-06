using Clinic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Infrastructure.Configurations
{
    public class DoctorConfigurations : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(e => e.DoctorId).HasName("PK__Doctors__2DC00EDF119A2508");

            builder.Property(e => e.DoctorId)
                 .ValueGeneratedNever()
                 .HasColumnName("DoctorID");
            builder.Property(e => e.PersonId).HasColumnName("PersonID");
            builder.Property(e => e.Specialization).HasMaxLength(100);

            builder.HasOne(d => d.Person).WithMany(p => p.Doctors)
                 .HasForeignKey(d => d.PersonId)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("FK_Doctors_Persons");

        }
    }
}
