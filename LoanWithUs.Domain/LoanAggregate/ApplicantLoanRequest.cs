using LoanWithUs.Common;
using LoanWithUs.Domain.UserAggregate;
using LoanWithUs.Exceptions;

namespace LoanWithUs.Domain
{
    /// <summary>
    /// درخواست وام درخواستگر
    /// </summary>
    public class ApplicantLoanRequest : AggregateRoot
    {
        public ApplicantLoanRequest(Applicant applicant, Supporter supporter, LoanLadderFrame loanLadderFrame, LoanLadderInstallmentsCount loanLadderInstallments, string reason, IApplicantLoanRequestDomainService _applicantLoanRequestDomainService)
        {
            var isValid = _applicantLoanRequestDomainService.ValidateFrameByApplicant(applicant, loanLadderFrame).Result;
            if (!isValid)
                throw new InvalidDomainInputException("امکان درخواست این وام برای شما درخواستگر گرامی وجود ندارد");
            var allPreviousDone = _applicantLoanRequestDomainService.CheckPreviousRequestAllDone(applicant).Result;
            if (!allPreviousDone)
            {
                throw new InvalidDomainInputException("درخواستگر گرامی شما در حال حاضر امکان ثبت درخواست جدید برای شما وجود ندارد");
            }
            Applicant = applicant;
            Supporter = supporter;
            LoanLadderFrame = loanLadderFrame;
            //TODO: Validate Permit of Installment Count

            LoanLadderInstallmentsCount = loanLadderInstallments;
            State = ApplicantLoanRequestState.SendByApplicant;
            Reason = reason;
            CreateDate = DateTime.Now;
            if (Responses == null)
            {
                Responses = new List<ApplicantLoanRequestResponse>();
            }
            Responses.Add(new ApplicantLoanRequestResponse(State, "درخواست وام شما ثبت شد"));
        }

        public void SupporterResponse(bool isAccepted, string description)
        {
            if (Responses == null)
            {
                Responses = new List<ApplicantLoanRequestResponse>();
            }
            State = isAccepted ? ApplicantLoanRequestState.AcceptedBySupporter : ApplicantLoanRequestState.RejectedBySupporter;

            Responses.Add(new ApplicantLoanRequestResponse(State, description));
        }

        public void AdminAccept(bool isAccepted, string description)
        {
            if (Responses == null)
            {
                Responses = new List<ApplicantLoanRequestResponse>();
            }
            //Check Previous State
            if (State != ApplicantLoanRequestState.AcceptedBySupporter)
            {
                throw new InvalidDomainInputException("پشتیبان درخواست وام درخواستگر را رد کرده است.");
            }
            State = isAccepted ? ApplicantLoanRequestState.ReadyToPay : ApplicantLoanRequestState.RejectedBySupporter;

            Responses.Add(new ApplicantLoanRequestResponse(State, description));
        }

        public Loan PaiedRequest(LoanWithUsFile receipt)
        {
            //Check Previous State
            if (State != ApplicantLoanRequestState.ReadyToPay)
            {
                throw new InvalidDomainInputException("ادمین درخواست وام درخواستگر را رد کرده است.");
            }
            State = ApplicantLoanRequestState.Paied;
            //ToDo:add to message resourses
            Responses.Add(new ApplicantLoanRequestResponse(State, "درخواست وام شما با مبلغ 11111 با موفقیت پرداخت شد..."));
            return new Loan(this.LoanLadderFrame.Amount,this.Applicant, this.LoanLadderInstallmentsCount.Count);

        }

        public int SupporterId { get; private set; }
        public string Reason { get; private set; }
        public DateTime CreateDate { get; private set; }
        public ApplicantLoanRequestState State { get; private set; }
        public LoanLadderFrame LoanLadderFrame { get; private set; }
        public LoanLadderInstallmentsCount LoanLadderInstallmentsCount { get; set; }
        public List<ApplicantLoanRequestResponse> Responses { get; set; }
        public Applicant Applicant { get; }
        public Supporter Supporter { get; }
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
