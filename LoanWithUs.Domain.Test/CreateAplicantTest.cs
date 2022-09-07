using FluentAssertions;
using LoanWithUs.Domain.UserAggregate;

namespace LoanWithUs.Domain.Test
{
    public class CreateAplicantTest
    {
        [Fact]
        public void Applicant_should_Be_Created_With_Mobile_Number()
        {
            string mobile = "+989124804347";
            Applicant applicant = new Applicant(mobile);
            applicant.IdentityInformation.MobileNumber.Should().Be(mobile);
        }
    }
}