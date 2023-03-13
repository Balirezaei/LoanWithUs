using LoanWithUs.Common.DefinedType;
using LoanWithUs.Exceptions;

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

        internal Supporter(string nationalCode, MobileNumber mobileNumber, SupporterCredit initCredit, ISupporterDomainService supporterDomainService)
        {
            if (supporterDomainService.IsNationalReservedWithOtherSupporter(0, nationalCode).Result)
                throw new InvalidDomainInputException("کد ملی تکراریست");

            if (supporterDomainService.IsMobileReservedWithOtherSupporter(0, mobileNumber).Result)
                throw new InvalidDomainInputException("شماره موبایل تکراریست");

            
            IdentityInformation = new IdentityInformation(mobileNumber, nationalCode);
            this.SupporterCredit = initCredit;
            this.RegisterationDate = DateTime.Now;
        }

        public Applicant RegisterNewApplicant(MobileNumber mobileNumber, string nationalCode, string firstName, string lastName, IApplicantDomainService domainService)
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