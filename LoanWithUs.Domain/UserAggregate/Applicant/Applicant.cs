using LoanWithUs.Common;
using LoanWithUs.Common.DefinedType;
using LoanWithUs.Common.Enum;
using LoanWithUs.Common.ExtentionMethod;
using LoanWithUs.Exceptions;
using LoanWithUs.Resources;

namespace LoanWithUs.Domain
{

    /// <summary>
    /// درخواستگر
    /// </summary>
    public class Applicant : User
    {
        protected Applicant() { }

        public virtual LoanLadderFrame CurrentLoanLadderFrame { get; private set; }
        public virtual List<ApplicantLoanLadder> ApplicantLoanLadderHistory { get; set; }
        public int CurrentLoanLadderFrameId { get; private set; }

        public virtual Supporter Supporter { get; private set; }
        public int SupporterId { get; private set; }
        public virtual List<ApplicantLoanRequest> LoanRequests { get; set; }

        //public Loan ActiveLoan { get; set; }

        #region LoanRequest
        public ApplicantLoanRequest RequestNewLoan(string reason, string description, Amount amount, LoanLadderInstallmentsCount installmentsCount, IApplicantLoanRequestDomainService _applicantLoanRequestDomainService, IDateTimeServiceProvider dateProvider)
        {

            if (this.UserConfirmation == null || !this.UserConfirmation.TotalConfirmation)
                throw new DomainException(Messages.ApplicantLoanRequestNotConfirmedInfo);

            var supporterCredit = Supporter.GetAvailableCredit();
            if (supporterCredit < amount)
            {
                throw new DomainException(Messages.ApplicantLoanRequestInsufficientSupporterCredit);
            }

            if (amount > CurrentLoanLadderFrame.Amount)
            {
                throw new InvalidDomainInputException(Messages.ApplicantLoanRequestInvalidAmount);
            }

            var request = new ApplicantLoanRequest(this, Supporter, CurrentLoanLadderFrame, installmentsCount, amount, reason, description, _applicantLoanRequestDomainService, dateProvider);
            if (LoanRequests == null)
            {
                LoanRequests = new List<ApplicantLoanRequest>();
            }
            LoanRequests.Add(request);

            return request;

        }
        public ApplicantLoanRequest DeactiveLoanRequest(IApplicantLoanRequestDomainService domainService)
        {
            if (domainService.HasOpenRequest(this).Result)
            {
                var inprogressState = ApplicantLoanRequestState.ApplicantRequested.GetInprogressRequestState();

                var openRequest = LoanRequests.Where(m => inprogressState.Contains(m.LastState)).FirstOrDefault();
                openRequest.StateMachine.Cancel();

                return openRequest;
            }
            throw new Exception(Messages.LoanRequestInvalidStateChange);
        }

        #endregion


        ////ToDo:Remove Imediatelyyy
        //public Applicant(MobileNumber mobileNumber, string nationalCode)
        //{
        //    var isAvailable = false;// domainService.IsMobileReservedWithOtherUserType(mobileNumber).Result;
        //    if (isAvailable)
        //    {
        //        throw new InvalidDomainInputException("امکان ثبت نام شماره تلفن به عنوان درخواستگر فراهم نمی باشد.لطفن با مدیر سامانه تماس بگیرید.");
        //    }
        //    this.IdentityInformation = new IdentityInformation(mobileNumber, nationalCode);
        //    //this.UserLogins = this.UserLogins ?? new List<UserLogin>();
        //    //this.UserLogins.Add(new UserLogin(DateTime.Now.AddMinutes(2)));
        //    this.RegisterationDate = DateTime.Now;
        //}

        /// <summary>
        ///It should be Internal beacuse of client can not create new instance of Applicant
        ///And Only Supporter can register new Applicant
        /// </summary>
        /// <param name="mobileNumber"></param>
        /// <param name="domainService"></param>
        /// <exception cref="InvalidDomainInputException"></exception>
        internal Applicant(Supporter supporter, MobileNumber mobileNumber, string nationalCode, string firstName, string lastName, IApplicantDomainService domainService, IDateTimeServiceProvider dateProvider)
        {
            var isMobileAvailable = domainService.IsMobileReservedWithAllUserType(Id, mobileNumber).Result;
            if (isMobileAvailable)
            {
                throw new InvalidDomainInputException("امکان ثبت نام شماره تلفن به عنوان درخواستگر فراهم نمی باشد.لطفن با مدیر سامانه تماس بگیرید.");
            }
            Supporter = supporter;

            var isNationalCodeAvailable = domainService.IsNationalReservedWithAllUserType(Id, nationalCode).Result;
            if (isNationalCodeAvailable)
            {
                throw new InvalidDomainInputException("to do.");
            }
            IdentityInformation = new IdentityInformation(mobileNumber, nationalCode);
            PersonalInformation = new PersonalInformation(firstName, lastName);

            CurrentLoanLadderFrame = domainService.InitLoaderForApplicant().Result;
            CurrentLoanLadderFrameId = domainService.InitLoaderForApplicant().Result.Id;

            this.ApplicantLoanLadderHistory = new List<ApplicantLoanLadder>();
            this.ApplicantLoanLadderHistory.Add(new ApplicantLoanLadder(CurrentLoanLadderFrameId, "نردبان یکم _ ثبت نام درخواستگر", dateProvider));

            RegisterationDate = dateProvider.GetDate();

            UserConfirmation = UserConfirmation.NotConfirmedInstance();

        }

        public class PersonalInformationBuilder {
            private string firstName;
            private string lastName;
            private string motherFullName;
            private string fatherFullName;
            private DateTime birthDate;
            private string identityNumber;
            private string job;
            private bool isMale;
            private bool isMarried;
            private int childrenCount;
            private int minimumIncom;

            public PersonalInformationBuilder WithNameAndGender(string firstName, string lastName,bool isMale)
            {
                this.firstName = firstName;
                this.lastName = lastName;
                this.isMale=isMale;
                return this;
            }

            public PersonalInformationBuilder WithParentName(string motherFullName, string fatherFullName) {

                this.motherFullName = motherFullName;
                this.fatherFullName = fatherFullName;
                return this;
            }
            public PersonalInformationBuilder WithMarriageInfo(bool isMarried,int childrenCount)
            {
                this.isMarried = isMarried;
                this.childrenCount = childrenCount;
                return this;
            }
            public PersonalInformationBuilder WithJobInfo(string job,int minimumIncome)
            {
                this.job = job;
                this.minimumIncom = minimumIncome;
                return this;
            }
            public PersonalInformation Builder()
            {
            //    string firstName, string lastName,  string motherFullName, string fatherFullName, DateTime birthDate, 
            //string identityNumber, string job, bool isMale, bool isMarried, int childrenCount, int minimumIncome
                return new PersonalInformation(firstName, lastName, motherFullName, fatherFullName, birthDate, identityNumber, job, isMale, isMarried, childrenCount, minimumIncom);
            }
        }

        public void UpdatePersonalInformation(PersonalInformation personalInformation) { 
                if (EducationalInformation == null)
         {
        //   ,
        //    
        // 
        // 
        // 
        // 
        // 
        // IsMale 
        //  
        // 
        // 
    }
            else
            {

            }
        }

        public void UpdateEducationalInformation(EducationLevel educationallevel, string educationalSubject)
        {
            if (EducationalInformation == null)
            {
                EducationalInformation = new EducationalInformation(educationallevel, educationalSubject);
            }
            else
            {
                EducationalInformation.UpdateInformation(educationallevel, educationalSubject);
            }
        }

        public void UpdateBankInformation(string shabaNumber, string cardNumber, BankType bankType)
        {
            var bankIformation = new BankAccountInformation(shabaNumber, cardNumber, bankType);
            if (BankAccountInformations == null)
            {
                BankAccountInformations = new List<BankAccountInformation>();
            }
            BankAccountInformations.Add(bankIformation);

        }


        internal void ConfirmInfo()
        {
            this.UserConfirmation = new UserConfirmation(true, true, true, true, true);
        }


        public void MoveToNextLadderAfterLoanSettel(IApplicantDomainService domainService, IDateTimeServiceProvider dateProvider)
        {
            var next = domainService.NextLadderForApplicant(this.CurrentLoanLadderFrame).Result;

            if (next!=null)
            {
                this.CurrentLoanLadderFrame = next;
                this.ApplicantLoanLadderHistory.Add(new ApplicantLoanLadder(next.Id, "وام تسویه شده", dateProvider));
            }
        }
    }

}