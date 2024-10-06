using Clinic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Infrastructure.Configurations
{
    public class PatientConfigurations : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(e => e.PatientId).HasName("PK__Patients__970EC346A08EB619");

            builder.Property(e => e.PatientId)
                .ValueGeneratedNever()
                .HasColumnName("PatientID");
            builder.Property(e => e.PersonId).HasColumnName("PersonID");

            builder.HasOne(d => d.Person).WithMany(p => p.Patients)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Patients_Persons");
        }
    }
}
