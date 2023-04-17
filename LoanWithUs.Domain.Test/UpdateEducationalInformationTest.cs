using FluentAssertions;
using LoanWithUs.Domain.Test.Utility;
using LoanWithUs.Domain;
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
                applicant.UpdateEducationalInformation(Common.EducationLevel.Bachelor, null);
            };
            //Assertion
            comparison.Should().Throw<InvalidDomainInputException>();
        }

        [Fact]
        public void Applicant_Should_Work_Correctly_With_First_Insert_EducationalInformation()
        {
            //Setup
            var expectedEducationalSubject = "فناوری اطلاعات";
            var expectedEducationalLevel = Common.EducationLevel.Bachelor;
            //Excersice
            Applicant applicant = new ApplicantBuilder().Build();
            applicant.UpdateEducationalInformation(expectedEducationalLevel, expectedEducationalSubject);
            applicant.EducationalInformation.EducationalSubject.Should().Be(expectedEducationalSubject);
            applicant.EducationalInformation.LastEducationLevel.Should().Be(expectedEducationalLevel);
        }

        [Fact]
        public void Applicant_Should_Work_Correctly_OnUpdate_EducationalInformation()
        {
            var expectedEducationalSubject = "فناوری اطلاعات";
            var expectedEducationalLevel = Common.EducationLevel.Bachelor;

            //Excersice
            Applicant applicant = new ApplicantBuilder().WithDefaultEducationalInformation().Build();
            applicant.UpdateEducationalInformation(expectedEducationalLevel, expectedEducationalSubject);

            //Assertion
            applicant.EducationalInformation.EducationalSubject.Should().Be(expectedEducationalSubject);
            applicant.EducationalInformation.LastEducationLevel.Should().Be(expectedEducationalLevel);
        }

        [Fact]
        public void Applicant_Should_throw_Exception_OnInvalid_EducationalInformation()
        {
            var expectedEducationalSubject = "%#";
            var expectedEducationalLevel = Common.EducationLevel.Bachelor;

            Applicant applicant = new ApplicantBuilder().Build();


            //Excersice
            Action comparison = () =>
            {
                applicant.UpdateEducationalInformation(expectedEducationalLevel, expectedEducationalSubject);
            };

            //Assertion
            comparison.Should().Throw<InvalidDomainInputException>();
        }
    }
}