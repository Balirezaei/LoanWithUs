using LoanWithUs.Common.DefinedType;
using LoanWithUs.Domain.UserAggregate;
using LoanWithUs.Persistense.EF.ContextContainer;

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
                var supporter = admin.DefineNewSupporter(StaticDate.SupporterNationalCode, new MobileNumber (StaticDate.SupporterMobileNumber), domainServiceSupporter);
                context.Supporters.Add(supporter);
                context.SaveChanges();
            }
            if (!context.Applicants.Any())
            {
                var applicant = new ApplicantBuilder(context).WithMobileNumber(StaticDate.ApplicantMobileNumber).Build();
                context.Applicants.Add(applicant);
                context.SaveChanges();
            }
            //INSERT

        }
    }

    public static class StaticDate
    {
        public static int AdministratorId
        {
            get
            {
                return 1;
            }
        }
        public static int SupporterId
        {
            get
            {
                return 1;
            }
        }
        public static int ApplicantId
        {
            get
            {
                return 2;
            }
        }

        public static string SupporterNationalCode
        {
            get
            {
                return "0123456987";
            }
        }

        public static string SupporterMobileNumber
        {
            get
            {
                return "09121236548";
            }
        }

        public static string ApplicantMobileNumber
        {
            get
            {
                return "09381112233";
            }
        }
    }
}
