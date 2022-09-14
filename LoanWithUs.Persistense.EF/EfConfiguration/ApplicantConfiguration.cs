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

            builder.OwnsOne(m => m.EducationalInformation).ToTable("EducationalInformation");
            builder.OwnsOne(m => m.UserConfirmation).ToTable("UserConfirmation");
            builder.OwnsOne(m => m.AddressInformation).ToTable("AddressInformation");
            builder.OwnsOne(m => m.PersonalInformation).ToTable("PersonalInformation");
            builder.OwnsMany(m => m.UserDocuments).ToTable("UserDocument");
            builder.OwnsMany(m => m.BankAccountInformations).ToTable("BankAccountInformation");
            builder.OwnsMany(m => m.UserLogins).ToTable("UserLogin");
        }
    }

    //public class AddressInformationConfiguration : IEntityTypeConfiguration<AddressInformation>
    //{
    //    public void Configure(EntityTypeBuilder<AddressInformation> builder)
    //    {
    //        builder.HasNoKey();
    //    }
    //}

}
