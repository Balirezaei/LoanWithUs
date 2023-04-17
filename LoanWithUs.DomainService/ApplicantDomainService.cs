using LoanWithUs.Common.DefinedType;
using LoanWithUs.Domain;
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
        private ILoanLadderFrameRepository _loanLadderFrameRepository;


        public ApplicantDomainService(IApplicantReadRepository applicantReadRepository, ILoanLadderFrameRepository loanLadderFrameRepository)
        {
            this.applicantReadRepository = applicantReadRepository;
            _loanLadderFrameRepository = loanLadderFrameRepository;
        }

        public Task<LoanLadderFrame> InitLoaderForApplicant()
        {
            return _loanLadderFrameRepository.GetFirstStep();
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
