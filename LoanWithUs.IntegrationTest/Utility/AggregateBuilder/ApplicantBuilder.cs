using LoanWithUs.Common;
using LoanWithUs.Common.DefinedType;
using LoanWithUs.Domain;
using LoanWithUs.Persistense.EF.ContextContainer;
using NSubstitute;

namespace LoanWithUs.IntegrationTest.Utility
{
    internal class ApplicantBuilder
    {
        private MobileNumber _mobile = new MobileNumber("09124443377");
        private string _firstName = "applicant";
        private string _lastName = "applicant";
        private string _nationalCode = "0099887766";
        private IApplicantDomainService applicantDomainService;
        private Supporter _supporter;
        private LoanWithUsContext _loanWithUsContext;
        IDateTimeServiceProvider dateProvider;
        public ApplicantBuilder(LoanWithUsContext loanWithUsContext)
        {
            var _applicantDomainService = Substitute.For<IApplicantDomainService>();
            _applicantDomainService.IsMobileReservedWithAllUserType(default, default).ReturnsForAnyArgs(false);
            var loanLadderApplicantDomainService = Substitute.For<ILoanLadderFrameDomainService>();
            var stepOne = new LoanLadderFrameBuilder(loanLadderApplicantDomainService)
                              .WithTitle("نردبان اول")
                              .WithStep(1)
                              .WithTomanAmount(1000000)
                              .Build(1);
            _applicantDomainService.InitLoaderForApplicant().Returns(stepOne);

            applicantDomainService = _applicantDomainService;
            _loanWithUsContext = loanWithUsContext;
            _supporter = _loanWithUsContext.Supporters.FirstOrDefault();
            dateProvider = new DateTimeServiceProvider();
        }

        public ApplicantBuilder WithMobileNumber(string mobile)
        {
            _mobile = new MobileNumber(mobile);
            return this;
        }

        public ApplicantBuilder WithFirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }
        public ApplicantBuilder WithLastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }

        public ApplicantBuilder WithApplicantDomainService(IApplicantDomainService domainService)
        {
            applicantDomainService = domainService;
            return this;
        }

        public Applicant Build()
        {
            return _supporter.RegisterNewApplicant(_mobile, _nationalCode, _firstName, _lastName, applicantDomainService, dateProvider);
        }
    }
}