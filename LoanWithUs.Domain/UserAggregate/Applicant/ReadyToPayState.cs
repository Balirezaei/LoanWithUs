using LoanWithUs.Common.Enum;

namespace LoanWithUs.Domain
{
    public class ReadyToPayState : ApplicantLoanRequestStateMachine
    {
        public ReadyToPayState(ApplicantLoanRequest applicantLoanRequest) : base(applicantLoanRequest)
        {
        }

        public override void Cancel()
        {
            Become(ApplicantLoanRequestState.Canceled);
        }
        public override void Confirm()
        {
            Become(ApplicantLoanRequestState.Paied);
        }
        public override void Reject()
        {
            Become(ApplicantLoanRequestState.AdminRejected);
        }
    }



}