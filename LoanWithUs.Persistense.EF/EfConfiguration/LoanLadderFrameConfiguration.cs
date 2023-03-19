using LoanWithUs.Common.DefinedType;
using LoanWithUs.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LoanWithUs.Persistense.EF.EfConfiguration
{
    public class LoanLadderFrameConfiguration : IEntityTypeConfiguration<LoanLadderFrame>
    {
        public void Configure(EntityTypeBuilder<LoanLadderFrame> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id).ValueGeneratedOnAdd();


            builder.HasOne(m => m.RequiredParentLoan);
            //.WithMany(m => m.NextLoanLadderFrame)
            //.HasForeignKey(m => m.RequiredParentLoanId);

            builder.OwnsMany(m => m.LoanLadderFrameRequiredDocuments);
            builder.OwnsMany(m => m.AvalableInstallments);


            //    .HasData(new LoanLadderInstallmentsCount[]
            //{
            //    new LoanLadderInstallmentsCount(6),
            //    new LoanLadderInstallmentsCount(12),
            //    new LoanLadderInstallmentsCount(18),
            //    new LoanLadderInstallmentsCount(24),
            //    new LoanLadderInstallmentsCount(36),
            //});


            builder.Property(o => o.Amount)
                    .HasColumnName("Amount")
                    .HasConversion(
                        v => JsonConvert.SerializeObject(v),
                        v => JsonConvert.DeserializeObject<Amount>(v));


            var stepOne = new LoanLadderFrameBuilder(new FakeLoanLadderFrameDomainService())
                                .WithTitle("نردبان اول")
                                .WithStep(1)
                                .WithTomanAmount(1000000)
                                //.With6MoInstallment()
                                //.With12MoInstallment()
                                .Build(1);

            //var stepTow = new LoanLadderFrameBuilder()
            //                    .WithTitle("نردبان دوم")
            //                    .WithStep(2)
            //                    .WithParentLadder(stepOne)
            //                    .WithTomanAmount(2000000)
            //                    //.With6MoInstallment()
            //                    //.With12MoInstallment()
            //                    //.With18MoInstallment()
            //                    .Build(2);

            //var stepThree = new LoanLadderFrameBuilder()
            //                    .WithTitle("نردبان سوم")
            //                    .WithStep(3)
            //                    .WithParentLadder(stepTow)
            //                    .WithTomanAmount(4000000)
            //                    //.With6MoInstallment()
            //                    //.With12MoInstallment()
            //                    //.With18MoInstallment()
            //                    .Build(3);

            //var stepFour = new LoanLadderFrameBuilder()
            //                    .WithTitle("نردبان چهارم")
            //                    .WithStep(4)
            //                    .WithParentLadder(stepThree)
            //                    .WithTomanAmount(8000000)
            //                    //.With6MoInstallment()
            //                    //.With12MoInstallment()
            //                    //.With18MoInstallment()
            //                    .Build(4);

            //var stepFive = new LoanLadderFrameBuilder()
            //                    .WithTitle("نردبان پنجم")
            //                    .WithStep(5)
            //                    .WithParentLadder(stepFour)
            //                    .WithTomanAmount(16000000)
            //                    //.With12MoInstallment()
            //                    //.With18MoInstallment()
            //                    //.With24MoInstallment()
            //                    .Build(5);


            builder.HasData(new LoanLadderFrame[]
            {
                stepOne//,stepTow,stepThree,stepFour,stepFive
            });
        }
    }


    public class FakeLoanLadderFrameDomainService : ILoanLadderFrameDomainService
    {
        public async Task<bool> IsStepRepetitive(int step)
        {
            return false;
        }
    }
    //public class LoanLadderInstallmentsCountConfiguration : IEntityTypeConfiguration<LoanLadderInstallmentsCount>
    //{
    //    public void Configure(EntityTypeBuilder<LoanLadderInstallmentsCount> builder)
    //    {
    //        builder.HasKey(m => m.Count);
    //        builder.Property(m => m.Count).ValueGeneratedNever();
    //        builder.HasData(new LoanLadderInstallmentsCount[]
    //        {
    //            new LoanLadderInstallmentsCount(6),
    //            new LoanLadderInstallmentsCount(12),
    //            new LoanLadderInstallmentsCount(18),
    //            new LoanLadderInstallmentsCount(24),
    //            new LoanLadderInstallmentsCount(36),
    //        });
    //    }
    //}
}
