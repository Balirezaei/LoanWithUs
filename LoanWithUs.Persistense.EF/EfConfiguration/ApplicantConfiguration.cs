using LoanWithUs.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.Persistense.EF.EfConfiguration
{
    public class ApplicantConfiguration : IEntityTypeConfiguration<Applicant>
    {
        public void Configure(EntityTypeBuilder<Applicant> builder)
        {
            builder.ToTable("Applicant");
            //builder.HasKey(m => m.Id);
            //builder.HasIndex(m => m.IdentityInformation.MobileNumber).IsUnique();
            builder.OwnsOne(o => o.IdentityInformation,
               sa =>
               {
                   sa.Property(p => p.MobileNumber)
                   .HasMaxLength(11)
                   .IsRequired(true)
                   .HasColumnName("MobileNumber");
                   sa.Property(p => p.EmailAddress).HasMaxLength(150).IsRequired(false).HasColumnName("EmailAddress");
                   sa.Property(p => p.Password).HasMaxLength(50).IsRequired(false).HasColumnName("Password");
                   sa.Property(p => p.NationalCode).HasMaxLength(10).IsRequired(false).HasColumnName("NationalCode");
                   sa.HasIndex(p => p.MobileNumber).IsUnique();
               });

            //builder.Ignore(m => m.AddressInformation);

        }
    }

}
