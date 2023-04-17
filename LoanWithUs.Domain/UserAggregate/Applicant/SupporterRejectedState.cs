namespace LoanWithUs.Domain
{
    public class SupporterRejectedState : ApplicantLoanRequestStateMachine
    {
        public SupporterRejectedState(ApplicantLoanRequest applicantLoanRequest) : base(applicantLoanRequest)
        {
        }

    }



}