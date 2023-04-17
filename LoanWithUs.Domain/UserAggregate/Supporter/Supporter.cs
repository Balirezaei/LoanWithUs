using LoanWithUs.Common.DefinedType;
using LoanWithUs.Exceptions;

namespace LoanWithUs.Domain
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

        internal Supporter(string nationalCode, MobileNumber mobileNumber, Amount initialAmount, ISupporterDomainService supporterDomainService)
        {
            if (supporterDomainService.IsNationalReservedWithOtherSupporter(0, nationalCode).Result)
                throw new InvalidDomainInputException("کد ملی تکراریست");

            if (supporterDomainService.IsMobileReservedWithOtherSupporter(0, mobileNumber).Result)
                throw new InvalidDomainInputException("شماره موبایل تکراریست");


            IdentityInformation = new IdentityInformation(mobileNumber, nationalCode);
            SupporterCredit = new SupporterCredit(initialAmount);
            RegisterationDate = DateTime.Now;
        }

        public Applicant RegisterNewApplicant(MobileNumber mobileNumber, string nationalCode, string firstName, string lastName, IApplicantDomainService domainService)
        {
            return new Applicant(this, mobileNumber, nationalCode, firstName, lastName, domainService);
        }

        public Amount GetAvailableCredit()
        {
            return SupporterCredit.InitialAmount;
        }
    }

    public class SupporterCredit
    {
        protected SupporterCredit()
        {

        }

        public int Id { get; set; }
        public DateTime CreateDate { get; private set; }
        public Amount InitialAmount { get; private set; }

        public SupporterCredit(Amount amount)
        {
            InitialAmount = amount;
            CreateDate = DateTime.Now;
        }
    }
    //TODO : Complete The model
    /// <summary>
    /// صندوقچه پشتیبانان
    /// </summary>
    public class SupporterBox
    {
        public Supporter Supporter { get; private set; }
        public int LastBalance { get; set; }
    }

    public class SupporterBoxDebitCredit
    {

    }


}