namespace LoanWithUs.Domain
{
    public interface IApplicantLoanRequestRepository
    {
        Task<bool> HasOpenRequest(int applicant);
        void Update(ApplicantLoanRequest loanRequest);
    }

}
