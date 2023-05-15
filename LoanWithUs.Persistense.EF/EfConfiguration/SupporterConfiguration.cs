using LoanWithUs.Common.DefinedType;
using LoanWithUs.Common.Enum;
using LoanWithUs.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace LoanWithUs.Persistense.EF.EfConfiguration
{
    public class SupporterConfiguration : IEntityTypeConfiguration<Supporter>
    {
        public void Configure(EntityTypeBuilder<Supporter> builder)
        {
            builder.ToTable("Supporter");

            builder.OwnsMany(m => m.AcceptedApplicantLoanRequests, sa =>
            {
                sa.Property(x => x.Amount)
                        .HasColumnName("Amount").HasMaxLength(500)
                        .HasConversion(
                            v => JsonConvert.SerializeObject(v),
                            v => JsonConvert.DeserializeObject<Amount>(v));

            });

            //builder.HasKey(m => m.Id);
            //builder.HasIndex(m => m.IdentityInformation.MobileNumber).IsUnique();

            //builder.OwnsOne(o => o.IdentityInformation,
            //    sa =>
            //    {
            //        sa.Property(p => p.MobileNumber)
            //        .HasMaxLength(11)
            //        .IsRequired(true)
            //        .HasColumnName("MobileNumber")
            //         .HasConversion(
            //                v => v.mobileNumber,
            //                v => new MobileNumber(v)
            //                    );

            //        sa.Property(p => p.EmailAddress).HasMaxLength(150).IsRequired(false).HasColumnName("EmailAddress");
            //        sa.Property(p => p.Password).HasMaxLength(50).IsRequired(false).HasColumnName("Password");
            //        sa.Property(p => p.NationalCode).HasMaxLength(10).IsRequired(false).HasColumnName("NationalCode");
            //        sa.HasIndex(p => p.MobileNumber).IsUnique();
            //    });


            builder.OwnsOne(o => o.SupporterCredit, sa =>
            {

                sa.OwnsMany(x => x.Details, a =>
                {
                    a.Property(e => e.Type)
                   .HasConversion(
                   v => v.ToString(),
                   v => (SupporterDebitCreditType)Enum.Parse(typeof(SupporterDebitCreditType), v));


                    a.Property(x => x.Debit).HasConversion(
                            v => JsonConvert.SerializeObject(v),
                            v => JsonConvert.DeserializeObject<Amount>(v));


                    a.Property(x => x.Credit).HasConversion(
                         v => JsonConvert.SerializeObject(v),
                         v => JsonConvert.DeserializeObject<Amount>(v));

                });

                sa.Property(x => x.CurrentBalance)
                        .HasColumnName("CurrentBalance")
                        .HasConversion(
                            v => JsonConvert.SerializeObject(v),
                            v => JsonConvert.DeserializeObject<Amount>(v));

                sa.Property(x => x.InitialAmount)
.HasColumnName("InitialAmount")
.HasConversion(
v => JsonConvert.SerializeObject(v),
v => JsonConvert.DeserializeObject<Amount>(v));

                sa.ToTable("SupporterCredit");
            });





            //orderConfiguration.OwnsOne(p => p.OrderDetails, cb =>
            //{
            //    cb.OwnsOne(c => c.BillingAddress);
            //    cb.OwnsOne(c => c.ShippingAddress);
            //});

            //orderConfiguration.OwnsOne(p => p.Address).Property(p => p.Street).HasColumnName("ShippingStreet");

        }
    }

}
