namespace LoanWithUs.Domain
{
    public interface ILoanLadderFrameRepository
    {
        Task<LoanLadderFrame> GetFirstStep();
        IQueryable<LoanLadderFrame> GetAllLoanLadder();
        Task<bool> IsLoanLadderStepRepetitive(int step);
        Task Add(LoanLadderFrame loanLoadderFrame);
        Task<LoanLadderFrame> GetById(int loanFrameLadderId);
        void Update(LoanLadderFrame loanLadderFrame);
    }

}
