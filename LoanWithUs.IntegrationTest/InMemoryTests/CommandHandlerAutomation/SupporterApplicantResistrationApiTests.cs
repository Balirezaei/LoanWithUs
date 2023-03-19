using FluentAssertions;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common.DefinedType;
using LoanWithUs.Domain.UserAggregate;
using LoanWithUs.IntegrationTest.Utility.WebFactory;
using LoanWithUs.ViewModel;
using System.Net;

namespace LoanWithUs.IntegrationTest.InMemoryTests.CommandHandlerAutomation
{
    public class SupporterApplicantResistrationApiTests : IClassFixture<ToMemoryTestingBySupporterRole>
    {
        private readonly ToMemoryTestingBySupporterRole _toMemoryTesting;

        public SupporterApplicantResistrationApiTests(ToMemoryTestingBySupporterRole toMemoryTesting)
        {
            _toMemoryTesting = toMemoryTesting;
        }

        [Fact]
        public async Task Supporter_Register_Applicatn_with_correct_information()
        {
            var supporterId = _toMemoryTesting.CurrentUser.UserId;

            //Exersice
            var result = await _toMemoryTesting.SendAsync(new SupporterRegistereApplicantCommand()
            {
                FirstName = "FirstName",
                LastName = "LastName",
                MobileNumber = new MobileNumber("09366559898"),
                NationalCode = "9988776655",
                SupporterId = supporterId
            });

            //Verification
            result.ApplicantId.Should().NotBe(0);
        }

    }
}
