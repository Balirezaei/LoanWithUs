using FluentAssertions;
using LoanWithUs.ApplicationService.Contract.Administrator;
using LoanWithUs.Domain.UserAggregate;
using LoanWithUs.IntegrationTest.Utility;
using LoanWithUs.Persistense.EF.ContextContainer;
using MediatR;

namespace LoanWithUs.IntegrationTest.InMemoryTests
{
    public class AdministratorHandlerTests : IClassFixture<ToMemoryTesting>
    {

        private readonly ToMemoryTesting _toMemoryTesting;


        public AdministratorHandlerTests(ToMemoryTesting toMemoryTesting)
        {
            _toMemoryTesting = toMemoryTesting;
        }

        [Fact]
        public async Task AdminRegisteredSupporterQuery_Should_Work_Properly_With_Correct_Data()
        {
            var supporter = await _toMemoryTesting.WithMockSupporter();

            //Exersice
            var result = await _toMemoryTesting.SendAsync(new AdminRegisteredSupporterContract()
            {
                Order = "Id",
                PageNumber = 1,
                PageSize = 10,
                Sort = "desc"
            });

            //Verification
            result.Count().Should().BeGreaterThan(0);
            result.First().NationalCode.Should().Be(supporter.IdentityInformation.NationalCode);

        }

        [Fact]
        public async Task Admin_Can_Register_Supporter()
        {
            //Setup         
            var command = new AdminRegisterSupporterCommand()
            {
                AdminId = 1,
                MobileNo = "09124566547",
                NationalCode = "1234567899"
            };

            //Exersice
            var commandResult = await _toMemoryTesting.SendAsync(command);

            //Verification
            var actucal = await _toMemoryTesting.FindAsync<Supporter>(commandResult.Id);


            actucal.Should().NotBeNull();
            actucal.IdentityInformation.NationalCode.Should().Be(command.NationalCode);

        }

    }
}