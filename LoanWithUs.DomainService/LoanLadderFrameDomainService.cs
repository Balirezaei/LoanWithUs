using LoanWithUs.Domain;

namespace LoanWithUs.DomainService
{
    public class LoanLadderFrameDomainService: ILoanLadderFrameDomainService
    {
        private ILoanLadderFrameRepository _loanLadderFrameRepository;

        public LoanLadderFrameDomainService(ILoanLadderFrameRepository loanLadderFrameRepository)
        {
            _loanLadderFrameRepository = loanLadderFrameRepository;
        }

        public Task<bool> IsStepRepetitive(int step)
        {
            return _loanLadderFrameRepository.IsLoanLadderStepRepetitive(step);
        }
    }
}
