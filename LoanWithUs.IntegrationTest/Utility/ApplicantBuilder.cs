using LoanWithUs.Domain.UserAggregate;
using LoanWithUs.Persistense.EF.ContextContainer;
using NSubstitute;

namespace LoanWithUs.IntegrationTest.Utility
{
    internal class ApplicantBuilder
    {
        private string _mobile = "09124443377";
        private string _firstName = "applicant";
        private string _lastName = "applicant";
        private string _nationalCode = "0099887766";
        private IApplicantDomainService applicantDomainService;
        private Supporter _supporter;
        private LoanWithUsContext _loanWithUsContext;

        public ApplicantBuilder(LoanWithUsContext loanWithUsContext)
        {
            var _applicantDomainService = Substitute.For<IApplicantDomainService>();
            _applicantDomainService.IsMobileReservedWithOtherUserType(default).ReturnsForAnyArgs(false);
            applicantDomainService = _applicantDomainService;
            _loanWithUsContext = loanWithUsContext;
            _supporter = _loanWithUsContext.Supporters.FirstOrDefault();
        }

        public ApplicantBuilder WithMobileNumber(string mobile)
        {
            this._mobile = mobile;
            return this;
        }

        public ApplicantBuilder WithFirstName(string firstName)
        {
            this._firstName = firstName;
            return this;
        }
        public ApplicantBuilder WithLastName(string lastName)
        {
            this._lastName = lastName;
            return this;
        }

        public ApplicantBuilder WithApplicantDomainService(IApplicantDomainService domainService)
        {
            applicantDomainService = domainService;
            return this;
        }

        public Applicant Build()
        {
            return _supporter.RegisterNewApplicant(this._mobile, this._nationalCode, this._firstName, this._lastName, applicantDomainService);
        }
    }
}