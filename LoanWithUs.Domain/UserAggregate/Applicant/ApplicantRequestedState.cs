using LoanWithUs.Common.Enum;

namespace LoanWithUs.Domain
{
    public class ApplicantRequestedState : ApplicantLoanRequestStateMachine
    {
        public ApplicantRequestedState(ApplicantLoanRequest applicantLoanRequest) : base(applicantLoanRequest)
        {
        }

        public override void Cancel()
        {
            Become(ApplicantLoanRequestState.Canceled);
        }
        
        public override void Confirm()
        {
            Become(ApplicantLoanRequestState.SupporterAccepted);
        }

        public override void Reject()
        {
            Become(ApplicantLoanRequestState.SupporterRejected);
        }

    }



}