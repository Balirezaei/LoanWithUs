using LoanWithUs.Common.DefinedType;
using LoanWithUs.Domain;
using LoanWithUs.Persistense.EF.ContextContainer;
using Microsoft.EntityFrameworkCore;

namespace LoanWithUs.IntegrationTest.Utility.WebFactory
{
    public static class DbInitializer
    {
        public static void DbDataInitializer(this LoanWithUsContext context)
        {
            if (!context.Supporters.Any())
            {
                var admin = context.Administrators.First(m => m.Id == 1);
                var domainServiceSupporter = NSubstitute.Substitute.For<ISupporterDomainService>();
                var supporter = admin.DefineNewSupporter(StaticDate.SupporterNationalCode, new MobileNumber(StaticDate.SupporterMobileNumber), domainServiceSupporter);
                context.Supporters.Add(supporter);
                context.SaveChanges();
            }
            if (!context.Applicants.Any())
            {
                var applicant = new ApplicantBuilder(context).WithMobileNumber(StaticDate.ApplicantMobileNumber).Build();
                context.Applicants.Add(applicant);

                context.Entry(applicant.CurrentLoanLadderFrame).State = EntityState.Unchanged;


                // var changedEntriesCopy = context.ChangeTracker.Entries()
                //.Where(e => e.State == EntityState.Added)
                //.ToList();

                // foreach (var entry in changedEntriesCopy)
                // {
                //     if (entry.Entity.ToString().Contains("LoanLadder"))
                //     {
                //         entry.State = EntityState.Detached;
                //     }
                // }


                context.SaveChanges();
            }
            var loaddr = context.LoanLadderFrames.Include(m=>m.AvalableInstallments).First();

            if (!loaddr.AvalableInstallments.Any())
            {
                loaddr.InsertInstallment(6);
                loaddr.InsertInstallment(12);
                context.SaveChanges();
            }

        }
    }
}
