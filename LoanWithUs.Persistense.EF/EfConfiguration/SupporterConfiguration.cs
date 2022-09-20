using LoanWithUs.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanWithUs.Persistense.EF.EfConfiguration
{
    public class SupporterConfiguration : IEntityTypeConfiguration<Supporter>
    {
        public void Configure(EntityTypeBuilder<Supporter> builder)
        {
            builder.ToTable("Supporter");
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
