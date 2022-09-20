using FluentAssertions;
using LoanWithUs.Domain.Test.Utility;
using LoanWithUs.Domain.UserAggregate;
using LoanWithUs.Exceptions;
using NSubstitute;

namespace LoanWithUs.Domain.Test
{
    public class CreateAplicantTest
    {
        [Fact]
        public void Applicant_should_Be_Created_With_Mobile_Number()
        {
            string mobile = "09124804347";
            Applicant applicant = new ApplicantBuilder().WithmobileNumber(mobile).Build();
            applicant.IdentityInformation.MobileNumber.Should().Be(mobile);
        }


        [Fact]
        public void Applicant_should_Be_Created_With_LoginNewLoginRecord()
        {
            Applicant applicant = new ApplicantBuilder().Build();
            applicant.UserLogins.Count().Should().BeGreaterThan(0);
        }

        [Fact]
        public void SupporterUser_Could_not_beCreated_As_an_Applicant()
        {
            var applicantDomainService = Substitute.For<IApplicantDomainService>();
            applicantDomainService.IsMobileReservedWithOtherUserType(default).Returns(false);
            Action comparison = () => {
                new ApplicantBuilder().WithApplicantDomainService(applicantDomainService).Build();
            };
            comparison.Should().Throw<InvalidDomainInputException>();//.WithMessage(MessageResource.AuthorityDelegationExceptionIncorectEndDate);
        }
    }
}