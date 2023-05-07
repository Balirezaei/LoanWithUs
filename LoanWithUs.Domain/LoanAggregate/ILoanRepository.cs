namespace LoanWithUs.Domain
{
    public interface ILoanRepository
    {
        Task RegisterNewLoan(Loan loan);
    }
}
