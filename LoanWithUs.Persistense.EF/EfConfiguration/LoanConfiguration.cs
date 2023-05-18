using LoanWithUs.Common;
using LoanWithUs.Common.DefinedType;
using LoanWithUs.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
namespace LoanWithUs.Persistense.EF.EfConfiguration
{
    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.ToTable("Loan");

            builder.Property(x => x.Amount)
                        .HasColumnName("Amount")
                        .HasConversion(
                            v => JsonConvert.SerializeObject(v),
                            v => JsonConvert.DeserializeObject<Amount>(v));

            builder.HasOne(m => m.Requester)
                .WithMany(m => m.Loans)
                .HasForeignKey(m => m.RequesterId);

            builder.OwnsMany(m => m.LoanInstallments);
            builder.OwnsMany(m => m.LoanRequiredDocuments, sa =>
            {
                sa.HasOne(z => z.File).WithMany()
                .HasForeignKey(z => z.LoanWithUsFileId)
                .OnDelete(DeleteBehavior.NoAction);

                sa.Property(e => e.Type).HasMaxLength(30)
                .HasConversion(v => v.ToString(), v => (LoanRequiredDocumentType)Enum.Parse(typeof(LoanRequiredDocumentType), v));

                sa.Property(e => e.Description).HasMaxLength(100).HasConversion(
                            v => JsonConvert.SerializeObject(v),
                            v => JsonConvert.DeserializeObject<SupporterUserType>(v)); ;
                

            });
            //Sequence-LoanSerialNumber

            builder
             .Property(m => m.SerialNumber)
             .HasDefaultValueSql("(NEXT VALUE FOR [Sequence-LoanSerialNumber])");

        }
    }
}
