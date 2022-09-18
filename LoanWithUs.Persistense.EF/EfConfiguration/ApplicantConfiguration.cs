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
            builder.HasKey(m => m.Id);
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

            builder.OwnsOne(m => m.EducationalInformation).ToTable("ApplicantEducationalInformation");
            builder.OwnsOne(m => m.UserConfirmation).ToTable("ApplicantUserConfirmation");
            builder.OwnsOne(m => m.AddressInformation).ToTable("ApplicantAddressInformation");
            builder.OwnsOne(m => m.PersonalInformation).ToTable("ApplicantPersonalInformation");
            builder.OwnsMany(m => m.UserDocuments).ToTable("ApplicantUserDocument");
            builder.OwnsMany(m => m.BankAccountInformations).ToTable("ApplicantBankAccountInformation");
            builder.OwnsMany(m => m.UserLogins).ToTable("ApplicantUserLogin");
        }
    }


    public class SupporterConfiguration : IEntityTypeConfiguration<Supporter>
    {
        public void Configure(EntityTypeBuilder<Supporter> builder)
        {
            builder.ToTable("Supporter");
            builder.HasKey(m => m.Id);
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

            builder.OwnsOne(m => m.EducationalInformation).ToTable("SupporterEducationalInformation");
            builder.OwnsOne(m => m.UserConfirmation).ToTable("SupporterUserConfirmation");
            builder.OwnsOne(m => m.AddressInformation).ToTable("SupporterAddressInformation");
            builder.OwnsOne(m => m.PersonalInformation).ToTable("SupporterPersonalInformation");
            builder.OwnsMany(m => m.UserDocuments).ToTable("SupporterUserDocument");
            builder.OwnsMany(m => m.BankAccountInformations).ToTable("SupporterBankAccountInformation");
            builder.OwnsMany(m => m.UserLogins).ToTable("SupporterUserLogin");
        }
    }

}
