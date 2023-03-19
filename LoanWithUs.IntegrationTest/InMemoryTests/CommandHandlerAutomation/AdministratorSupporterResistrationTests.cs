using FluentAssertions;
using LoanWithUs.ApplicationService.Contract.Administrator;
using LoanWithUs.Common.DefinedType;
using LoanWithUs.Domain.UserAggregate;
using LoanWithUs.Exceptions;
using LoanWithUs.IntegrationTest.Utility.WebFactory;
using LoanWithUs.Persistense.EF.ContextContainer;
using MediatR;

namespace LoanWithUs.IntegrationTest.InMemoryTests.HandlerAutomation
{
    public class AdministratorSupporterResistrationTests : IClassFixture<ToMemoryTestingByAdminRole>
    {
        private readonly ToMemoryTestingByAdminRole _toMemoryTesting;

        public AdministratorSupporterResistrationTests(ToMemoryTestingByAdminRole toMemoryTesting)
        {
            _toMemoryTesting = toMemoryTesting;
        }

        [Fact]
        public async Task AdminRegisteredSupporterQuery_Should_Work_Properly_With_Correct_Data()
        {
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

        }

        [Fact]
        public async Task Admin_Can_Register_Supporter()
        {
            //Setup         
            var command = new AdminRegisterSupporterCommand()
            {
                AdminId = _toMemoryTesting.CurrentUser.UserId,
                MobileNumber = new MobileNumber("09124566547"),
                NationalCode = "0055664477"
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

            var command = new AdminRegisterSupporterCommand()
            {
                AdminId = 1,
                MobileNumber = new MobileNumber("09164585252"),
                NationalCode = StaticDate.SupporterNationalCode
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
            var command = new AdminRegisterSupporterCommand()
            {
                AdminId = 1,
                MobileNumber = new MobileNumber(StaticDate.SupporterMobileNumber),
                NationalCode = "1122334455"
            };

            //Exersice
            var action = () => _toMemoryTesting.SendAsync(command);

            //Verification
            await action.Should().ThrowAsync<InvalidDomainInputException>();

        }

    }
}