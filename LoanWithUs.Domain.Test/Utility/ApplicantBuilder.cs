using LoanWithUs.Common;
using LoanWithUs.Common.DefinedType;
using LoanWithUs.Domain;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.Domain.Test.Utility
{
    internal class ApplicantBuilder
    {
        private MobileNumber mobile = new MobileNumber("09124804347");
        private IApplicantDomainService applicantDomainService;
        private EducationalInformation educationalInformation = null;
        private IDateTimeServiceProvider dateProvider;
        private Supporter supporter;

        public ApplicantBuilder()
        {
            var _applicantDomainService = Substitute.For<IApplicantDomainService>();
            _applicantDomainService.IsMobileReservedWithAllUserType(default, default).ReturnsForAnyArgs(false);
            var loanLadderApplicantDomainService = Substitute.For<ILoanLadderFrameDomainService>();
            var stepOne = LoanLadderFrameFactory.StepOne();
            _applicantDomainService.InitLoaderForApplicant().Returns(stepOne);
            dateProvider = new DateTimeServiceProvider();
            supporter = new SupporterBuilder().Build();
            applicantDomainService = _applicantDomainService;
        }

        public ApplicantBuilder WithSupporter(Supporter supporter)
        {
            this.supporter = supporter;
            return this;
        }


        public ApplicantBuilder WithmobileNumber(string mobile)
        {
            this.mobile = new MobileNumber(mobile);
            return this;
        }

        public ApplicantBuilder WithApplicantDomainService(IApplicantDomainService domainService)
        {
            this.applicantDomainService = domainService;
            return this;
        }

        public Applicant Build()
        {
            var applicant = supporter
                .RegisterNewApplicant(this.mobile, "0011223366", "firstName", "lastName", applicantDomainService, dateProvider);
            //throw new NotImplementedException();
            // var applicant = new Applicant(mobile, applicantDomainService);
            // if (educationalInformation != null)
            // {
            //     applicant.UpdateEducationalInformation(educationalInformation.LastEducationLevel, educationalInformation.EducationalSubject);
            // }
            return applicant;
        }

        public ApplicantBuilder WithDefaultEducationalInformation()
        {
            educationalInformation = new EducationalInformation(Common.EducationLevel.Bachelor, "تست");
            return this;
        }
    }
}
