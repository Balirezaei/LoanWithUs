using LoanWithUs.Common.DefinedType;
using LoanWithUs.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .HasForeignKey(z=>z.LoanWithUsFileId)
                .OnDelete(DeleteBehavior.NoAction);
            });
            //Sequence-LoanSerialNumber

            builder
             .Property(m => m.SerialNumber)
             .HasDefaultValueSql("(NEXT VALUE FOR [Sequence-LoanSerialNumber])");

        }
    }
}
