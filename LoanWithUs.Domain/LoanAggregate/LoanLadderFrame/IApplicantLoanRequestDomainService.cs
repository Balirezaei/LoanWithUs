
namespace LoanWithUs.Domain
{
    public interface IApplicantLoanRequestDomainService
    {
        Task<bool> ValidateFrameByApplicant(Applicant applicant, LoanLadderFrame loanLadderFrame);
        Task<bool> HasOpenRequest(Applicant applicant);
        Task<bool> HasNotSettelledLoan(Applicant applicant);
    }

}
