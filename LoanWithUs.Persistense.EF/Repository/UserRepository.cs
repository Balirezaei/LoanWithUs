using LoanWithUs.Common.DefinedType;
using LoanWithUs.Domain;
using LoanWithUs.Persistense.EF.ContextContainer;
using Microsoft.EntityFrameworkCore;

namespace LoanWithUs.Persistense.EF.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly LoanWithUsContext _context;

        public UserRepository(LoanWithUsContext context)
        {
            _context = context;
        }

        public Task<User> CheckUserActivationCode(MobileNumber mobileNumber, string code, string userAgent)
        {
            return _context.Users
                .Where(m => m.IdentityInformation.MobileNumber == mobileNumber
                &&
                m.UserLogins.Any(z => z.Code == code && z.ExpireDate > DateTime.Now && z.UserAgent == userAgent)

                )
                .FirstOrDefaultAsync();
        }

        public Task<User> FindUserByMobile(MobileNumber mobileNumber)
        {
            return _context.Users
                 .FirstOrDefaultAsync(m => m.IdentityInformation.MobileNumber == mobileNumber);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }
    }
}
