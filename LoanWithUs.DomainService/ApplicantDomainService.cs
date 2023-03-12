using LoanWithUs.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.DomainService
{
    public class ApplicantDomainService : IApplicantDomainService
    {
        private IApplicantReadRepository applicantReadRepository;

        public ApplicantDomainService(IApplicantReadRepository applicantReadRepository)
        {
            this.applicantReadRepository = applicantReadRepository;
        }

        public Task<bool> IsMobileReservedWithAllUserType(int currentUser, string mobileNumber)
        {
            return applicantReadRepository.CheckUserMobileAvailibilityWithAllUserType(currentUser,mobileNumber);
        }
    }
}
