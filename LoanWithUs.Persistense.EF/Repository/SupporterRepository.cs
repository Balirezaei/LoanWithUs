using LoanWithUs.Common.DefinedType;
using LoanWithUs.Domain.UserAggregate;
using LoanWithUs.Persistense.EF.ContextContainer;
using Microsoft.EntityFrameworkCore;

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

        public Task<bool> CheckMobileNumber(int exceptCurrentUser, MobileNumber mobileNumber)
        {
            return _context.Supporters.Where(m=>m.Id!=exceptCurrentUser && m.IdentityInformation.MobileNumber== mobileNumber).AnyAsync();
        }

        public Task<bool> CheckNationalCode(int exceptCurrentUser, string nationalCode)
        {
            return _context.Supporters.Where(m => m.Id != exceptCurrentUser && m.IdentityInformation.NationalCode == nationalCode).AnyAsync();
        }

        public IQueryable<Supporter> GetAllSupporter()
        {
            return _context.Supporters;
        }

        public Task<Supporter> GetSupporterById(int supporterId)
        {
            return _context.Supporters.Where(m => m.Id == supporterId).FirstOrDefaultAsync();
        }
    }
}
