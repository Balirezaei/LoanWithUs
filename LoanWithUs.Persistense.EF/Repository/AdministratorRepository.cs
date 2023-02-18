using LoanWithUs.Domain;
using LoanWithUs.Domain.UserAggregate;
using LoanWithUs.Persistense.EF.ContextContainer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.Persistense.EF.Repository
{
    public class AdministratorRepository : IAdministratorRepository
    {
        private readonly LoanWithUsContext _context;

        public AdministratorRepository(LoanWithUsContext context)
        {
            _context = context;
        }

        public Task<Administrator> CheckOtpCode(Guid key, string code, string userAgent)
        {
           return _context.Administrators.Where(m => m.UserLogins.Any(z => z.UserAgent == userAgent && z.Key == key && code == code && z.ExpireDate > DateTime.Now))
                .FirstOrDefaultAsync();
        }

        public Task<Administrator> GetAdministratorById(int id)
        {
            return _context.Administrators.FirstOrDefaultAsync(m => m.Id == id);
        }

        public Task<Administrator> GetAdministratorByUserName(string userName)
        {
            return _context.Administrators.FirstOrDefaultAsync(m => m.UserName == userName);
        }
    }
}
