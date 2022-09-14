using LoanWithUs.Domain.UserAggregate;

namespace LoanWithUs.Domain
{
    public interface IApplicantLoanRequestDomainService
    {
        Task<bool> ValidateFrameByApplicant(Applicant applicant, LoanLadderFrame loanLadderFrame);
        Task<bool> CheckPreviousRequestAllDone(Applicant applicant);
    }

}
