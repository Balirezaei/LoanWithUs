using LoanWithUs.Domain.UserAggregate;
using NSubstitute;

namespace LoanWithUs.IntegrationTest.Utility
{
    internal class ApplicantBuilder
    {
        private string mobile = "09124804347";
        private IApplicantDomainService applicantDomainService;

        public ApplicantBuilder()
        {
            var _applicantDomainService = Substitute.For<IApplicantDomainService>();
            _applicantDomainService.IsMobileReservedWithOtherUserType(default).ReturnsForAnyArgs(false);
            applicantDomainService = _applicantDomainService;
        }

        public ApplicantBuilder WithmobileNumber(string mobile)
        {
            this.mobile = mobile;
            return this;
        }

        public ApplicantBuilder WithApplicantDomainService(IApplicantDomainService domainService)
        {
            applicantDomainService = domainService;
            return this;
        }

        public Applicant Build()
        {
            return new Applicant(mobile, applicantDomainService);
        }
    }
}