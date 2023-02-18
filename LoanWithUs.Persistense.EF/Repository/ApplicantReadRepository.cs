using LoanWithUs.Domain.UserAggregate;
using LoanWithUs.Persistense.EF.ContextContainer;
using Microsoft.EntityFrameworkCore;

namespace LoanWithUs.Persistense.EF.Repository
{
    public class ApplicantReadRepository : IApplicantReadRepository
    {
        private readonly LoanWithUsContext _context;

        public ApplicantReadRepository(LoanWithUsContext context)
        {
            _context = context;
        }

        public Task<bool> CheckUserActivationCode(string mobile, string code, string userAgent)
        {
            return _context.Applicants
                .Where(m => m.IdentityInformation.MobileNumber == mobile
                &&
                m.UserLogins.Any(z => z.Code == code && z.ExpireDate > DateTime.Now && z.UserAgent == userAgent)

                )
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

        public Task<Applicant> FindFullApplicantAggregateById(int id)
        {
            return _context.Applicants.Where(m => m.Id == id)
                .Include(m => m.AddressInformation)
                .Include(m => m.EducationalInformation)
                .Include(m => m.BankAccountInformations)
                .Include(m => m.IdentityInformation)
                .Include(m => m.PersonalInformation)
                .FirstOrDefaultAsync();
        }

        Task<Applicant> IApplicantReadRepository.FindApplicantById(int id)
        {
            return _context.Applicants.Where(m => m.Id == id).FirstOrDefaultAsync();
        }
    }
}
