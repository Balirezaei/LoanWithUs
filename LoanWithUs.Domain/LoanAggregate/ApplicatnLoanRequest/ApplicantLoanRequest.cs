using LoanWithUs.Common;
using LoanWithUs.Common.DefinedType;
using LoanWithUs.Common.Enum;
using LoanWithUs.Common.ExtentionMethod;
using LoanWithUs.Exceptions;
using LoanWithUs.Resources;

namespace LoanWithUs.Domain
{
    /// <summary>
    /// درخواست وام درخواستگر
    /// </summary>
    public class ApplicantLoanRequest : AggregateRoot
    {
        protected ApplicantLoanRequest()
        {
        }

        internal ApplicantLoanRequest(Applicant applicant, Supporter supporter, LoanLadderFrame loanLadderFrame, LoanLadderInstallmentsCount loanLadderInstallments, Amount amount, string reason,string description, IApplicantLoanRequestDomainService _applicantLoanRequestDomainService, IDateTimeServiceProvider dateProvider)
        {
            var isValid = _applicantLoanRequestDomainService.ValidateFrameByApplicant(applicant, loanLadderFrame).Result;
            if (!isValid)
                throw new InvalidDomainInputException("امکان درخواست این وام برای شما درخواستگر گرامی وجود ندارد");

            var openRequest = _applicantLoanRequestDomainService.HasOpenRequest(applicant).Result;
            if (openRequest)
            {
                throw new InvalidDomainInputException(Messages.ApplicantLoanRequestWithOpenRequest);
            }

            var openLoan = _applicantLoanRequestDomainService.HasNotSettelledLoan(applicant).Result;
            if (openLoan)
            {
                throw new InvalidDomainInputException(Messages.ApplicantLoanRequestWithOpenLoan);
            }
            if (!loanLadderFrame.AvalableInstallments.Any(z => z.Count == loanLadderInstallments.Count))
            {
                throw new InvalidDomainInputException(Messages.ApplicantLoanRequestWithInvalidInstallment);
            }
            Applicant = applicant;
            Supporter = supporter;
            LoanLadderFrame = loanLadderFrame;
            //TODO: Validate Permit of Installment Count
            InstallmentsCount = loanLadderInstallments.Count;
            LastState = ApplicantLoanRequestState.ApplicantRequested;
            Reason = reason;
            Description = description;

            this.Amount = amount;

            CreateDate = dateProvider.GetDate();

            if (Flows == null)
            {
                Flows = new List<ApplicantLoanRequestFlow>();
            }
            Flows.Add(new ApplicantLoanRequestFlow(LastState, "درخواست وام شما ثبت شد", dateProvider));
        }

        internal void SupporterResponse(bool isAccepted, string description, IDateTimeServiceProvider dateProvider)
        {
            if (LastState != ApplicantLoanRequestState.ApplicantRequested)
            {
                throw new DomainException("عملیات غیر مجاز");
            }
            if (Flows == null)
            {
                Flows = new List<ApplicantLoanRequestFlow>();
            }
            if (isAccepted)
            {
                StateMachine.Confirm();
            }
            else
            {
                StateMachine.Reject();
            }
            Flows.Add(new ApplicantLoanRequestFlow(this.LastState, description, dateProvider));
        }

        internal void AdminResponse(bool isAccepted, string description, IDateTimeServiceProvider dateProvider)
        {
            if (LastState != ApplicantLoanRequestState.SupporterAccepted)
            {
                throw new DomainException("عملیات غیر مجاز");
            }
            if (Flows == null)
            {
                Flows = new List<ApplicantLoanRequestFlow>();
            }
            if (isAccepted)
            {
                StateMachine.Confirm();
            }
            else
            {
                StateMachine.Reject();
            }
            Flows.Add(new ApplicantLoanRequestFlow(this.LastState, description, dateProvider));
        }

        public void CancelRequest(IDateTimeServiceProvider dateProvider)
        {
            if (Flows == null)
            {
                Flows = new List<ApplicantLoanRequestFlow>();
            }
            StateMachine.Cancel();
            Flows.Add(new ApplicantLoanRequestFlow(this.LastState, Messages.ApplicantCancelTheRequest, dateProvider));
        }

        public Loan PaiedRequest(LoanWithUsFile receipt,float loanWage, IDateTimeServiceProvider dateProvider)
        {
            //Check Previous State
            if (LastState != ApplicantLoanRequestState.ReadyToPay)
            {
                throw new InvalidDomainInputException("ادمین درخواست وام درخواستگر را رد کرده است.");
            }
            StateMachine.Confirm();
            //ToDo:add to message resourses
            if (Flows == null)
            {
                Flows = new List<ApplicantLoanRequestFlow>();
            }
            Flows.Add(new ApplicantLoanRequestFlow(LastState, String.Format(Messages.AdminAcceptLoanRequest, this.Amount.amount.ToStringSplit3Digit()), dateProvider));
            return new Loan(this, receipt,loanWage, dateProvider);
        }

        public int Id { get; set; }
        public string Reason { get; private set; }
        public string Description { get;private set; }
        public DateTime CreateDate { get; private set; }
        public ApplicantLoanRequestState LastState { get; internal set; }
        private ApplicantLoanRequestStateMachine _State;
        public ApplicantLoanRequestStateMachine StateMachine
        {
            get => _State ??= ApplicantLoanRequestStateMachine.New(this, LastState);
            internal set => _State = value;
        }
        
        public LoanLadderFrame LoanLadderFrame { get; private set; }
        public int LoanLadderFrameId { get; private set; }
        public int InstallmentsCount { get; private set; }
        public Amount Amount { get; private set; }
        public List<ApplicantLoanRequestFlow> Flows { get; private set; }
        public Applicant Applicant { get; private set; }
        public int ApplicantId { get; private set; }
        public Supporter Supporter { get; private set; }
        public int SupporterId { get; private set; }
        public string TrackingNumber { get; private set; }

    }

}
