namespace LoanWithUs.Domain
{
    public class AdminRejectedState : ApplicantLoanRequestStateMachine
    {
        public AdminRejectedState(ApplicantLoanRequest applicantLoanRequest) : base(applicantLoanRequest)
        {
        }

    }



}