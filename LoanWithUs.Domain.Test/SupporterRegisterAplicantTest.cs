using FluentAssertions;
using LoanWithUs.Common.DefinedType;
using LoanWithUs.Domain.Test.Utility;
using LoanWithUs.Domain.UserAggregate;
using LoanWithUs.Exceptions;
using NSubstitute;

namespace LoanWithUs.Domain.Test
{
    public class SupporterRegisterAplicantTest
    {

        [Fact]
        public void Supporter_Can_Register_Applicant()
        {
            //Fixture Setup
            var supporter = new SupporterBuilder().Build();

            string fistName = "fistName";
            string lastName = "";
            var mobileNumber = new MobileNumber("09124341212");
            string nationalCode = "123456712";

            var applicantDomainService = Substitute.For<IApplicantDomainService>();
            var loanLadderApplicantDomainService = Substitute.For<ILoanLadderFrameDomainService>();
            var stepOne = new LoanLadderFrameBuilder(loanLadderApplicantDomainService)
                         .WithTitle("‰—œ»«‰ «Ê·")
                         .WithStep(1)
                         .WithTomanAmount(1000000)
                         .Build(1);
            applicantDomainService.InitLoaderForApplicant().Returns(stepOne);

            //Exersice
            var applicant = supporter.RegisterNewApplicant(mobileNumber, nationalCode, fistName, lastName, applicantDomainService);

            applicant.Should().NotBeNull();
            applicant.PersonalInformation.FirstName.Should().Be(fistName);
            applicant.IdentityInformation.MobileNumber.Should().Be(mobileNumber);
        }

        [Fact]
        public void Supporter_Receives_Exception_On_Reserved_MobileNo()
        {
            //Fixture Setup
            var supporter = new SupporterBuilder().Build();

            string fistName = "fistName";
            string lastName = "";
            var mobileNumber = supporter.IdentityInformation.MobileNumber;
            string nationalCode = "123456712";

            var applicantDomainService = Substitute.For<IApplicantDomainService>();
            applicantDomainService.IsMobileReservedWithAllUserType(default, default).ReturnsForAnyArgs(true);

            //Exersice
            var applicantCreatFunc = () => supporter.RegisterNewApplicant(mobileNumber, nationalCode, fistName, lastName, applicantDomainService);

            applicantCreatFunc.Should().Throw<InvalidDomainInputException>();
        }
    }
}