using LoanWithUs.Domain;
using LoanWithUs.Persistense.EF.ContextContainer;

namespace LoanWithUs.Persistense.EF.Repository
{
    public class LoanRepository: ILoanRepository
    {
        private readonly LoanWithUsContext _context;

        public LoanRepository(LoanWithUsContext context)
        {
            _context = context;
        }

        public async Task RegisterNewLoan(Loan loan)
        {
            _ = _context.Loans.AddAsync(loan);
        }

    }
}
