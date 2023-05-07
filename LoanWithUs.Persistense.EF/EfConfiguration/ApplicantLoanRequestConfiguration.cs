using LoanWithUs.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LoanWithUs.Common.Enum;
using Newtonsoft.Json;
using LoanWithUs.Common.DefinedType;

namespace LoanWithUs.Persistense.EF.EfConfiguration
{
    public class ApplicantLoanRequestConfiguration : IEntityTypeConfiguration<ApplicantLoanRequest>
    {
        public void Configure(EntityTypeBuilder<ApplicantLoanRequest> builder)
        {
            builder.ToTable("ApplicantLoanRequest");
            builder.HasKey(m => m.Id);
            builder.HasOne(m => m.LoanLadderFrame)
                .WithMany()
                .HasForeignKey(m => m.LoanLadderFrameId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(m => m.Applicant)
                .WithMany(m => m.LoanRequests)
                .HasForeignKey(m => m.ApplicantId);

            builder.HasOne(m => m.Supporter).WithMany().HasForeignKey(m => m.SupporterId).OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(m => m.Flows);

            builder
                    .Property(e => e.LastState)
                    .HasConversion(
                    v => v.ToString(),
                    v => (ApplicantLoanRequestState)Enum.Parse(typeof(ApplicantLoanRequestState), v));

            builder.Ignore(e => e.StateMachine);

            builder.Property(o => o.Amount)
                .HasColumnName("Amount")
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<Amount>(v));

            builder
                .Property(m => m.TrackingNumber)
                .HasDefaultValueSql("(FORMAT(GETDATE(), 'yyyy', 'fa')+'/'+cast((NEXT VALUE FOR [Sequence-TrackingNumber]) AS NVARCHAR))");

        }
    }
}
