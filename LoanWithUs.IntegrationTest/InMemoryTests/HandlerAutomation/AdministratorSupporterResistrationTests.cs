using FluentAssertions;
using LoanWithUs.ApplicationService.Contract.Administrator;
using LoanWithUs.Domain.UserAggregate;
using LoanWithUs.Exceptions;
using LoanWithUs.IntegrationTest.Utility.WebFactory;
using LoanWithUs.Persistense.EF.ContextContainer;
using MediatR;

namespace LoanWithUs.IntegrationTest.InMemoryTests.HandlerAutomation
{
    public class AdministratorSupporterResistrationTests : IClassFixture<ToMemoryTesting>
    {
        private readonly ToMemoryTesting _toMemoryTesting;

        public AdministratorSupporterResistrationTests(ToMemoryTesting toMemoryTesting)
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


        [Fact]
        public async Task Admin_on_Register_Supporter_with_douplicate_NationalCode_Receive_Exception()
        {
            //Setup         
            var supporter = await _toMemoryTesting.WithMockSupporter();

            var command = new AdminRegisterSupporterCommand()
            {
                AdminId = 1,
                MobileNo = "09164585252",
                NationalCode = supporter.IdentityInformation.NationalCode
            };

            //Exersice
            var action = () => _toMemoryTesting.SendAsync(command);


            //Verification
            await action.Should().ThrowAsync<InvalidDomainInputException>();

        }

        [Fact]
        public async Task Admin_on_Register_Supporter_with_douplicate_MobileNo_Receive_Exception()
        {
            //Setup         
            var supporter = await _toMemoryTesting.WithMockSupporter();

            var command = new AdminRegisterSupporterCommand()
            {
                AdminId = 1,
                MobileNo = supporter.IdentityInformation.MobileNumber,
                NationalCode = "1122334455"
            };

            //Exersice
            var action = () => _toMemoryTesting.SendAsync(command);

            //Verification
            await action.Should().ThrowAsync<InvalidDomainInputException>();

        }

    }
}