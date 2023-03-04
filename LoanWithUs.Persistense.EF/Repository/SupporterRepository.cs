using LoanWithUs.Domain.UserAggregate;
using LoanWithUs.Persistense.EF.ContextContainer;

namespace LoanWithUs.Persistense.EF.Repository
{
    public class SupporterRepository : ISupporterRepository
    {
        private readonly LoanWithUsContext _context;

        public SupporterRepository(LoanWithUsContext context)
        {
            _context = context;
        }

        public void Add(Supporter supporter)
        {
            _context.Supporters.Add(supporter);
        }

        public IQueryable<Supporter> GetAllSupporter()
        {
            return _context.Supporters;
        }
    }
}
