using LoanWithUs.Common;
using LoanWithUs.Common.DefinedType;
using LoanWithUs.Common.ExtentionMethod;
using LoanWithUs.Exceptions;
using LoanWithUs.Resources;

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

        public virtual SupporterCredit SupporterCredit { get;private set; }

        internal Supporter(string nationalCode, MobileNumber mobileNumber, Amount initialAmount, ISupporterDomainService supporterDomainService, IDateTimeServiceProvider dateProvider)
        {
            if (supporterDomainService.IsNationalReservedWithOtherSupporter(0, nationalCode).Result)
                throw new InvalidDomainInputException("کد ملی تکراریست");

            if (supporterDomainService.IsMobileReservedWithOtherSupporter(0, mobileNumber).Result)
                throw new InvalidDomainInputException("شماره موبایل تکراریست");


            IdentityInformation = new IdentityInformation(mobileNumber, nationalCode);
            SupporterCredit = new SupporterCredit(initialAmount, dateProvider);
            RegisterationDate = dateProvider.GetDate();
            this.AcceptedApplicantLoanRequests = new List<AcceptedApplicantLoanRequest>();
        }

        public void UpdatePersonalInfo(string firstName, string lastName)
        {
            this.PersonalInformation = new PersonalInformation(firstName, lastName);
        }

        public Applicant RegisterNewApplicant(MobileNumber mobileNumber, string nationalCode, string firstName, string lastName, IApplicantDomainService domainService, IDateTimeServiceProvider dateProvider)
        {
            //TODO: Check Credit to registring new applicant
            return new Applicant(this, mobileNumber, nationalCode, firstName, lastName, domainService, dateProvider);
        }

        public Amount GetAvailableCredit()
        {
            var totalConfirmedRequest = (this.AcceptedApplicantLoanRequests.Where(m => m.IsOpen).Sum(m => m.Amount.amount)).ToToamn();

            return SupporterCredit.InitialAmount - totalConfirmedRequest;
        }
        // TODO: Concurrency
        public void ConfirmApplicantLoanRequest(ApplicantLoanRequest loanRequest, IDateTimeServiceProvider dateProvider)
        {
            if (GetAvailableCredit() < loanRequest.Amount)
            {
                throw new DomainException(Messages.SupporterInsufficientAmountToConfirmRequest);
            }
            if (loanRequest.SupporterId != this.Id)
                throw new DomainException(Messages.SupporterNotAllowedForThisApplicant);
            loanRequest.SupporterResponse(true, "درخواست توسط پشتیبان تایید شد.", dateProvider);
            AppendToAcceptedApplicantLoanRequests(new AcceptedApplicantLoanRequest(loanRequest.TrackingNumber, loanRequest.ApplicantId, loanRequest.SupporterId, loanRequest.Amount, dateProvider));
        }

        public void RejectApplicantLoanRequest(ApplicantLoanRequest loanRequest, IDateTimeServiceProvider dateProvider)
        {
            if (loanRequest.SupporterId != this.Id)
                throw new DomainException(Messages.SupporterNotAllowedForThisApplicant);
            loanRequest.SupporterResponse(false, "درخواست توسط پشتیبان تایید شد.", dateProvider);

        }
        public virtual List<AcceptedApplicantLoanRequest> AcceptedApplicantLoanRequests { get; set; }

        private void AppendToAcceptedApplicantLoanRequests(AcceptedApplicantLoanRequest acceptedApplicantLoanRequest)
        {
            if (AcceptedApplicantLoanRequests == null)
                AcceptedApplicantLoanRequests = new List<AcceptedApplicantLoanRequest>();

            AcceptedApplicantLoanRequests.Add(acceptedApplicantLoanRequest);

        }

        public void CloseAcceptedLoanRequest(ApplicantLoanRequest loanRequest)
        {
            var openRequest = AcceptedApplicantLoanRequests.FirstOrDefault(m => m.IsOpen && m.ApplicantId == loanRequest.ApplicantId);

            openRequest.CloseRequest();
        }
    }

    public class AcceptedApplicantLoanRequest
    {
        protected AcceptedApplicantLoanRequest() { }
        public AcceptedApplicantLoanRequest(string trackingNumber, int applicantId, int supporterId, Amount amount, IDateTimeServiceProvider dateProvider)
        {
            TrackingNumber = trackingNumber;
            ApplicantId = applicantId;
            SupporterId = supporterId;
            Amount = amount;
            ConfirmedDate = dateProvider.GetDate();
            IsOpen = true;
        }

        public string TrackingNumber { get; private set; }
        public int ApplicantId { get; private set; }
        public int SupporterId { get; private set; }
        public Amount Amount { get; private set; }
        public DateTime ConfirmedDate { get; private set; }
        public bool IsOpen { get; private set; }
        public void CloseRequest()
        {
            IsOpen = false;
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

        public SupporterCredit(Amount amount, IDateTimeServiceProvider dateProvider)
        {
            InitialAmount = amount;
            CreateDate = dateProvider.GetDate();
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