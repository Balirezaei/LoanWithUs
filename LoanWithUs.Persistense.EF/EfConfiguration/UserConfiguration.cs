using LoanWithUs.Common;
using LoanWithUs.Common.DefinedType;
using LoanWithUs.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanWithUs.Persistense.EF.EfConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.RegisterationDate).HasColumnName("RegisterationDate");
            //builder.Ignore(m => m.IdentityInformation);

            builder.OwnsOne(m => m.EducationalInformation).ToTable("EducationalInformation");
            builder.OwnsOne(m => m.UserConfirmation).ToTable("UserConfirmation");
            builder.OwnsOne(m => m.AddressInformation).ToTable("AddressInformation");

            builder.OwnsOne(o => o.IdentityInformation,
           sa =>
           {
               sa.Property(p => p.MobileNumber)
               .HasMaxLength(11)
               .IsRequired(true)
               .HasColumnName("MobileNumber")
                .HasConversion(
                        v => v.mobileNumber,
                        v => new MobileNumber(v)
                            );
               ;
               sa.Property(p => p.EmailAddress).HasMaxLength(150).IsRequired(false).HasColumnName("EmailAddress");
               sa.Property(p => p.Password).HasMaxLength(50).IsRequired(false).HasColumnName("Password");
               sa.Property(p => p.NationalCode).HasMaxLength(10).IsRequired(false).HasColumnName("NationalCode");
               sa.HasIndex(p => p.MobileNumber).IsUnique();
           });

            builder.OwnsOne(m => m.PersonalInformation).ToTable("PersonalInformation");

            builder.OwnsOne(o => o.PersonalInformation,
             sa =>
             {
                 sa.Property(p => p.FatherFullName).HasMaxLength(150).IsRequired(false).HasColumnName("FatherFullName");
                 sa.Property(p => p.MotherFullName).HasMaxLength(150).IsRequired(false).HasColumnName("MatherFullName");
                 sa.Property(p => p.FirstName).HasMaxLength(20).IsRequired(true).HasColumnName("FirstName");
                 sa.Property(p => p.LastName).HasMaxLength(20).IsRequired(true).HasColumnName("LastName");
                 sa.Property(p => p.Job).HasMaxLength(50).IsRequired(false).HasColumnName("Job");
                 sa.Property(p => p.IdentityNumber).HasMaxLength(15).IsRequired(false).HasColumnName("IdentityNumber");
             });

            builder.OwnsMany(m => m.UserDocuments).ToTable("UserDocument");
            builder.OwnsMany(m => m.BankAccountInformations).ToTable("AccountInformation");
            builder.OwnsMany(m => m.BankAccountInformations, sa =>
            {
                sa.Property(z => z.BankType).HasMaxLength(30).HasConversion(v => v.ToString(), v => (BankType)Enum.Parse(typeof(BankType), v));

            });

            builder.OwnsOne(m => m.EducationalInformation, sa =>
            {
                sa.Property(z => z.LastEducationLevel).HasMaxLength(30).HasConversion(v => v.ToString(), v => (EducationLevel)Enum.Parse(typeof(EducationLevel), v));

            });
            builder.OwnsMany(m => m.UserLogins).ToTable("UserLogin");

        }
    }

}
