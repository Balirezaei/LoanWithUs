namespace LoanWithUs.Domain
{
    public interface ILoanLadderFrameRepository
    {
        Task<LoanLadderFrame> GetFirstStep();
        Task<LoanLadderFrame> GetNextStep(LoanLadderFrame currentladder);
        IQueryable<LoanLadderFrame> GetAllLoanLadder();
        Task<bool> IsLoanLadderStepRepetitive(int step);
        Task Add(LoanLadderFrame loanLoadderFrame);
        Task<LoanLadderFrame> GetById(int loanFrameLadderId);
        void Update(LoanLadderFrame loanLadderFrame);

    }

}
