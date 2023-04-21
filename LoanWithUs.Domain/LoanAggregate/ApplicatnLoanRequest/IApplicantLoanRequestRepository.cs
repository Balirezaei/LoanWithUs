namespace LoanWithUs.Domain
{
    public interface IApplicantLoanRequestRepository
    {
        Task<bool> HasOpenRequest(int applicant);
        Task<ApplicantLoanRequest> FindApplicantLoanRequest(int requestId);
        void Update(ApplicantLoanRequest loanRequest);
        IQueryable<ApplicantLoanRequest> GetAllOpenRequestOfSupporter(int supporterId);
    }

}
