using LoanWithUs.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanWithUs.Persistense.EF.EfConfiguration
{
    public class ApplicantConfiguration : IEntityTypeConfiguration<Applicant>
    {
        public void Configure(EntityTypeBuilder<Applicant> builder)
        {
            builder.ToTable("Applicant");
            //builder.HasKey(m => m.Id);
            //builder.HasIndex(m => m.IdentityInformation.MobileNumber).IsUnique();
        

            builder.HasOne(m => m.CurrentLoanLadderFrame).WithMany().HasForeignKey(m=>m.CurrentLoanLadderFrameId);

            //builder.OwnsMany(m => m.ApplicantLoanLadderHistory, sa =>
            //{
            //    sa.Property(z=>z.LoanLaddrFrameId).
            //});
            builder.HasMany(m => m.ApplicantLoanLadderHistory);
            builder.HasMany(m => m.LoanRequests);

            //builder.HasOne(m => m.Reporter)
            // .WithMany(m => m.ReporterRiskReports)
            // .HasForeignKey(m => m.ReporterId)
            // .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne(m => m.ActiveLoan);
        }
    }

}
