using LoanWithUs.Common.DefinedType;
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

        public Task<bool> IsMobileReservedWithAllUserType(int currentUser, MobileNumber mobileNumber)
        {
            return applicantReadRepository.CheckUserMobileAvailibilityWithAllUserType(currentUser,mobileNumber);
        }

        public Task<bool> IsNationalReservedWithAllUserType(int currentUser, string nationalCode)
        {
            return applicantReadRepository.CheckUserNationalCodeAvailibilityWithAllUserType(currentUser, nationalCode);
        }
    }
}
