using Clinic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Infrastructure.Configurations
{
    public class PersonConfigurations : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(e => e.PersonId).HasName("PK__Persons__AA2FFB8587F22B37");

            builder.Property(e => e.PersonId)
                .ValueGeneratedNever()
                .HasColumnName("PersonID");
            builder.Property(e => e.Address).HasMaxLength(200);
            builder.Property(e => e.Email).HasMaxLength(100);
            builder.Property(e => e.Gender).HasMaxLength(1);
            builder.Property(e => e.NameAr).HasMaxLength(100);
            builder.Property(e => e.NameEn).HasMaxLength(100);

            builder.Property(e => e.PhoneNumber).HasMaxLength(20);
        }
    }
}
