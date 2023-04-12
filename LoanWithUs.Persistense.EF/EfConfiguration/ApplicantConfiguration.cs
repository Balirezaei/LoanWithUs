using LoanWithUs.Common.DefinedType;
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
        

            builder.HasOne(m => m.CurrentLoanLadderFrame);//.WithMany(z=>z.Applicants).;

            //builder.HasOne(m => m.ActiveLoan);
        }
    }

}
