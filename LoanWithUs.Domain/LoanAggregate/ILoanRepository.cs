namespace LoanWithUs.Domain
{
    public interface ILoanRepository
    {
        Task RegisterNewLoan(Loan loan);
        Task<Loan> GetActiveLoan(int userId);
        Task<Loan> GetActiveLoanWithDependency(int userId);
    }
}
