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
    public class ApplicantRepository : IApplicantRepository
    {
        private readonly LoanWithUsContext _context;

        public ApplicantRepository(LoanWithUsContext context)
        {
            _context = context;
        }

        public async Task CreateApplicant(Applicant applicant)
        {
            _ = _context.Applicants.AddAsync(applicant);
        }

        public void Update(Applicant applicant)
        {
            _context.Applicants.Update(applicant);
        }
    }

    public class ApplicantReadRepository : IApplicantReadRepository
    {
        private readonly LoanWithUsContext _context;

        public ApplicantReadRepository(LoanWithUsContext context)
        {
            _context = context;
        }

        public Task<bool> CheckUserActivationCode(string mobile, string code)
        {
            return _context.Applicants
                .Where(m => m.IdentityInformation.MobileNumber == mobile && m.UserLogins.Any(z => z.Code == code && z.ExpireDate > DateTime.Now))
                .AnyAsync();
        }

        public Task<bool> CheckUserMobileAvailibilityWithAllUserType(string mobile)
        {
            return _context.Supporters.AnyAsync(m => m.IdentityInformation.MobileNumber == mobile);
        }

        public Task<Applicant> FindApplicantByIdIncludeEducationalInformation(int id)
        {
            return _context.Applicants.Where(m => m.Id == id).Include(m => m.EducationalInformation).FirstOrDefaultAsync();
        }

        public Task<Applicant> FindApplicantByMobile(string mobile)
        {
            return _context.Applicants
                 .FirstOrDefaultAsync(m => m.IdentityInformation.MobileNumber == mobile);
        }

        Task<Applicant> IApplicantReadRepository.FindApplicantById(int id)
        {
            return _context.Applicants.Where(m => m.Id == id).FirstOrDefaultAsync();
        }
    }
}
