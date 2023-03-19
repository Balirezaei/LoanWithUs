using LoanWithUs.Common.DefinedType;
using LoanWithUs.Domain.UserAggregate;
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

        public ApplicantBuilder()
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
            var applicant = new SupporterBuilder()
                .Build()
                .RegisterNewApplicant(this.mobile, "0011223366", "firstName", "lastName", applicantDomainService);
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

    public class AdministratorBuilder
    {
        public Administrator Build()
        {
            return new Administrator(1, "admin", "admin", "09121231234", "1234567891", "admin", "admin");
        }
    }
}
