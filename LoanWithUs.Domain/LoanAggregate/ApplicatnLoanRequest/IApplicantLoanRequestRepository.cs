namespace LoanWithUs.Domain
{
    public interface IApplicantLoanRequestRepository
    {
        Task<bool> HasOpenRequest(int applicant);
        Task<ApplicantLoanRequest> FindApplicantLoanRequest(int requestId);
        Task<ApplicantLoanRequest> FindActiveApplicantLoanRequest(int applicantId);
        Task<ApplicantLoanRequest> FindApplicantLoanRequestForAdmin(int requestId);
        
        void Update(ApplicantLoanRequest loanRequest);
        IQueryable<ApplicantLoanRequest> GetAllOpenLoanRequestOfSupporter(int supporterId);
        IQueryable<ApplicantLoanRequest> GetAllOpenRequest();
    }

}
