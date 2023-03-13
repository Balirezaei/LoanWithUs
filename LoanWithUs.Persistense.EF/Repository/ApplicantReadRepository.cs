using LoanWithUs.Common.DefinedType;
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

        public Task<bool> CheckUserActivationCode(MobileNumber mobileNumber, string code, string userAgent)
        {
            return _context.Applicants
                .Where(m => m.IdentityInformation.MobileNumber == mobileNumber
                &&
                m.UserLogins.Any(z => z.Code == code && z.ExpireDate > DateTime.Now && z.UserAgent == userAgent)

                )
                .AnyAsync();
        }

        public Task<bool> CheckUserMobileAvailibilityWithAllUserType(int currentUserId, MobileNumber mobileNumber)
        {
            return _context.Supporters.AnyAsync(m => m.Id != currentUserId && m.IdentityInformation.MobileNumber == mobileNumber);
        }

        public Task<bool> CheckUserNationalCodeAvailibilityWithAllUserType(int currentUserId, string nationalCode)
        {
            return _context.Supporters.AnyAsync(m => m.Id != currentUserId && m.IdentityInformation.NationalCode == nationalCode);
        }

        public Task<Applicant> FindApplicantByIdIncludeEducationalInformation(int id)
        {
            return _context.Applicants.Where(m => m.Id == id).Include(m => m.EducationalInformation).FirstOrDefaultAsync();
        }

        public Task<Applicant> FindApplicantByMobile(MobileNumber mobileNumber)
        {
            return _context.Applicants
                 .FirstOrDefaultAsync(m => m.IdentityInformation.MobileNumber == mobileNumber);
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
