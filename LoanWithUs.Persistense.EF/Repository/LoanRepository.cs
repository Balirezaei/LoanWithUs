using LoanWithUs.Domain;
using LoanWithUs.Persistense.EF.ContextContainer;
using Microsoft.EntityFrameworkCore;

namespace LoanWithUs.Persistense.EF.Repository
{
    public class LoanRepository: ILoanRepository
    {
        private readonly LoanWithUsContext _context;

        public LoanRepository(LoanWithUsContext context)
        {
            _context = context;
        }

        public Task<Loan> GetActiveLoan(int userId)
        {
            return _context.Loans.Where(m => m.RequesterId == userId).FirstOrDefaultAsync();
        }

        public Task<List<Loan>> GetActiveLoanGroupOfApplicant(int[] userIds)
        {
            return _context.Loans.Where(m => userIds.Contains( m.RequesterId )).ToListAsync();
        }

        public Task<Loan> GetActiveLoanWithDependency(int userId)
        {
            return _context.Loans.Where(m => m.RequesterId == userId).Include(m=>m.LoanInstallments).Include(m=>m.ReciptFile).FirstOrDefaultAsync();
        }

        public async Task RegisterNewLoan(Loan loan)
        {
            _ = _context.Loans.AddAsync(loan);
        }

    }
}
