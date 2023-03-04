namespace LoanWithUs.Domain.UserAggregate
{
    public class Supporter : User
    {
        protected Supporter()
        {

        }
        //public static Supporter DefineNewSupporterByAdministrator(Administrator creator, string nationalCode, string mobileNumber)
        //{
        //   return new Supporter()
        //    {
        //        IdentityInformation = new IdentityInformation(mobileNumber, nationalCode)
        //    };
        //}
        public SupporterCredit SupporterCredit { get; set; }

        internal Supporter(string nationalCode, string mobileNumber, SupporterCredit initCredit)
        {
            IdentityInformation = new IdentityInformation(mobileNumber, nationalCode);
            this.SupporterCredit = initCredit;
            this.RegisterationDate = DateTime.Now;
        }

        public Applicant RegisterNewApplicant(string mobileNumber, string nationalCode, string firstName, string lastName, IApplicantDomainService domainService)
        {
            return new Applicant(mobileNumber, nationalCode, firstName, lastName, domainService);
        }

        public long GetAvailableCredit()
        {
            return SupporterCredit.Amount;
        }
    }

    public class SupporterCredit
    {
        protected SupporterCredit()
        {

        }

        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public long Amount { get; set; }
        public MoneyUnit Money { get; set; }

        public SupporterCredit(long amount, MoneyUnit money)
        {
            Amount = amount;
            Money = money;
        }
    }
}