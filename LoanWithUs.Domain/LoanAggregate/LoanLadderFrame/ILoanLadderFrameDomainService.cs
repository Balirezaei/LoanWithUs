namespace LoanWithUs.Domain
{
    public interface ILoanLadderFrameDomainService
    {
        Task<bool> IsStepRepetitive(int step);
    }

}
