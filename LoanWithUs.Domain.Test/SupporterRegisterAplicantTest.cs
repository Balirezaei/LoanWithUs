using FluentAssertions;
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
            string mobileNumber = "09124341212";
            string nationalCode = "123456712";

            var applicantDomainService = Substitute.For<IApplicantDomainService>();

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
            string mobileNumber = supporter.IdentityInformation.MobileNumber;
            string nationalCode = "123456712";

            var applicantDomainService = Substitute.For<IApplicantDomainService>();
            applicantDomainService.IsMobileReservedWithAllUserType(default, default).ReturnsForAnyArgs(true);

            //Exersice
            var applicantCreatFunc = () => supporter.RegisterNewApplicant(mobileNumber, nationalCode, fistName, lastName, applicantDomainService);

            applicantCreatFunc.Should().Throw<InvalidDomainInputException>();
        }
    }
}