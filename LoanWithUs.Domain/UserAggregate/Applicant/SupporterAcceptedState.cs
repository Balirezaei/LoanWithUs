using LoanWithUs.Common.Enum;

namespace LoanWithUs.Domain
{
    public class SupporterAcceptedState : ApplicantLoanRequestStateMachine
    {
        public SupporterAcceptedState(ApplicantLoanRequest applicantLoanRequest) : base(applicantLoanRequest)
        {
        }

        public override void Cancel()
        {
            Become(ApplicantLoanRequestState.Canceled);
        }
        public override void Confirm()
        {
            Become(ApplicantLoanRequestState.ReadyToPay);
        }
        public override void Reject()
        {
            Become(ApplicantLoanRequestState.AdminRejected);
        }
    }



}