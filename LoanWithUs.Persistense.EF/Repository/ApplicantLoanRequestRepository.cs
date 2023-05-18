using LoanWithUs.Common.Enum;
using LoanWithUs.Common.ExtentionMethod;
using LoanWithUs.Domain;
using LoanWithUs.Persistense.EF.ContextContainer;
using Microsoft.EntityFrameworkCore;

namespace LoanWithUs.Persistense.EF.Repository
{
    public class ApplicantLoanRequestRepository : IApplicantLoanRequestRepository
    {
        private readonly LoanWithUsContext _context;

        public ApplicantLoanRequestRepository(LoanWithUsContext context)
        {
            _context = context;
        }

        public Task<bool> HasOpenRequest(int applicant)
        {
            var inprogressState = ApplicantLoanRequestState.ApplicantRequested.GetInprogressRequestState();
            return _context.ApplicantLoanRequests.Where(m => m.Applicant.Id == applicant && inprogressState.Contains(m.LastState)).AnyAsync();
        }

        public Task<ApplicantLoanRequest> FindApplicantLoanRequest(int requestId)
        {
            return _context.ApplicantLoanRequests.Where(m => m.Id == requestId).FirstOrDefaultAsync();
        }

        public Task<ApplicantLoanRequest> FindApplicantLoanRequestForAdmin(int requestId)
        {
            return _context.ApplicantLoanRequests.Where(m => m.Id == requestId)
                .Include(m=>m.Supporter)
                .ThenInclude(m=>m.PersonalInformation)
                .FirstOrDefaultAsync();
        }

        public void Update(ApplicantLoanRequest loanRequest)
        {
            _context.ApplicantLoanRequests.Update(loanRequest);
        }

        public IQueryable<ApplicantLoanRequest> GetAllOpenLoanRequestOfSupporter(int supporterId)
        {
            var inprogressState = ApplicantLoanRequestState.ApplicantRequested.GetInprogressRequestState();
            return _context.ApplicantLoanRequests
                .Where(m => m.Applicant.SupporterId == supporterId && inprogressState.Contains(m.LastState))
                .Include(m => m.Applicant.PersonalInformation);
        }

        public IQueryable<ApplicantLoanRequest> GetAllOpenRequest()
        {
            var inprogressState = ApplicantLoanRequestState.ApplicantRequested.GetInprogressRequestState();
            return _context.ApplicantLoanRequests
                .Where(m => inprogressState.Contains(m.LastState))
                .Include(m => m.Applicant.PersonalInformation)
                .Include(m => m.Supporter.PersonalInformation)
                ;
        }

        public Task<ApplicantLoanRequest> FindActiveApplicantLoanRequest(int applicantId)
        {
            var inprogressState = ApplicantLoanRequestState.ApplicantRequested.GetInprogressRequestState();
            return _context.ApplicantLoanRequests.Where(m => m.ApplicantId == applicantId && inprogressState.Contains(m.LastState)).FirstOrDefaultAsync();
        }
    }
}
