using FluentAssertions;
using LoanWithUs.Domain.Test.Utility;
using LoanWithUs.Domain.UserAggregate;
using LoanWithUs.Exceptions;

namespace LoanWithUs.Domain.Test
{
    public class UpdateEducationalInformationTest
    {
        [Fact]
        public void Applicant_Update_EducationalInformation_should_Throw_Exception_OnNullInput()
        {
            Applicant applicant = new ApplicantBuilder().Build();
            //Excersice
            Action comparison = () =>
            {
                applicant.UpdateEducationalInformation(null, null);
            };
            //Assertion
            comparison.Should().Throw<InvalidDomainInputException>();
        }

        [Fact]
        public void Applicant_Should_Work_Correctly_With_First_Insert_EducationalInformation()
        {
            //Setup
            var expectedEducationalSubject = "فناوری اطلاعات";
            var expectedEducationalLevel = "لیسانس";
            //Excersice
            Applicant applicant = new ApplicantBuilder().Build();
            applicant.UpdateEducationalInformation(expectedEducationalSubject, expectedEducationalLevel);
            applicant.EducationalInformation.EducationalSubject.Should().Be(expectedEducationalSubject);
            applicant.EducationalInformation.LastEducationLevel.Should().Be(expectedEducationalLevel);
        }

        [Fact]
        public void Applicant_Should_Work_Correctly_OnUpdate_EducationalInformation()
        {
            var expectedEducationalSubject = "فناوری اطلاعات";
            var expectedEducationalLevel = "لیسانس";

            //Excersice
            Applicant applicant = new ApplicantBuilder().WithDefaultEducationalInformation().Build();
            applicant.UpdateEducationalInformation(expectedEducationalSubject, expectedEducationalLevel);

            //Assertion
            applicant.EducationalInformation.EducationalSubject.Should().Be(expectedEducationalSubject);
            applicant.EducationalInformation.LastEducationLevel.Should().Be(expectedEducationalLevel);
        }

        [Fact]
        public void Applicant_Should_throw_Exception_OnInvalid_EducationalInformation()
        {
            var expectedEducationalSubject = "%#";
            var expectedEducationalLevel = "لیسانس";

            Applicant applicant = new ApplicantBuilder().Build();


            //Excersice
            Action comparison = () =>
            {
                applicant.UpdateEducationalInformation(expectedEducationalSubject, expectedEducationalLevel);
            };

            //Assertion
            comparison.Should().Throw<InvalidDomainInputException>();
        }
    }
}