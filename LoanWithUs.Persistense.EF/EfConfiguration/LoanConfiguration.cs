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
    //public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    //{
    //    public void Configure(EntityTypeBuilder<Loan> builder)
    //    {
    //        builder.ToTable("Loan");

    //        builder.Property(x => x.Amount)
    //                    .HasColumnName("Amount")
    //                    .HasConversion(
    //                        v => JsonConvert.SerializeObject(v),
    //                        v => JsonConvert.DeserializeObject<Amount>(v));

    //        builder.HasOne(m => m.Requester)
    //            .WithMany(m => m.Loans)
    //            .HasForeignKey(m => m.RequesterId);

    //        builder.OwnsMany(m => m.LoanInstallments);


    //    }
    //}
}
