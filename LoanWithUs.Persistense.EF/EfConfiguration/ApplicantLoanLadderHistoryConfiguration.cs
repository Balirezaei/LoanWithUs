using LoanWithUs.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanWithUs.Persistense.EF.EfConfiguration
{
    public class ApplicantLoanLadderHistoryConfiguration : IEntityTypeConfiguration<ApplicantLoanLadder>
    {
        public void Configure(EntityTypeBuilder<ApplicantLoanLadder> builder)
        {
            builder.HasKey(m => m.Id);

            builder.HasOne(a => a.LoanLadderFrame)
                .WithMany(a => a.ApplicantLoanLadders)
                .HasForeignKey(a=>a.LoanLaddrFrameId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }

}
