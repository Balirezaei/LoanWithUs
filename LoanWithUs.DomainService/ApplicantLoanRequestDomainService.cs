using LoanWithUs.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.DomainService
{
    public class ApplicantLoanRequestDomainService : IApplicantLoanRequestDomainService
    {
        private readonly IApplicantReadRepository _applicantReadRepository;
        private readonly IApplicantLoanRequestRepository _applicantLoanRequestRepository;

        public ApplicantLoanRequestDomainService(IApplicantReadRepository applicantReadRepository, IApplicantLoanRequestRepository applicantLoanRequestRepository)
        {
            _applicantReadRepository = applicantReadRepository;
            _applicantLoanRequestRepository = applicantLoanRequestRepository;
        }

        public async Task<bool> HasNotSettelledLoan(Applicant applicant)
        {
            //TODO : Loan Repository
            return false;
        }

        public Task<bool> HasOpenRequest(Applicant applicant)
        {
           return _applicantLoanRequestRepository.HasOpenRequest(applicant.Id);
        }
       

        public async Task<bool> ValidateFrameByApplicant(Applicant applicant, LoanLadderFrame loanLadderFrame)
        {
            var ladderHistory = await _applicantReadRepository.GetApplicantLoanLadders(applicant.Id);
            var expctedLadder = ladderHistory.OrderByDescending(m => m.CreateDate).First().LoanLadderFrame;
            return expctedLadder.Amount == loanLadderFrame.Amount;
        }
    }
}
