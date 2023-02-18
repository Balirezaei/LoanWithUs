namespace LoanWithUs.Domain.UserAggregate
{
    public class Supporter : User
    {

        public static void DefineNewSupporterByAdministrator(Administrator creator, string nationalCode, string mobileNumber)
        {
            new Supporter()
            {
                IdentityInformation = new IdentityInformation(mobileNumber, nationalCode)
            };
        }

        protected Supporter()
        {

        }
        public Applicant RegisterNewApplicant(string mobileNumber, string nationalCode, string firstName, string lastName, IApplicantDomainService domainService)
        {
            return new Applicant(mobileNumber, nationalCode, firstName, lastName, domainService);
        }

    }
    public class SupporterCredit
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public long Amount { get; set; }
    }
}