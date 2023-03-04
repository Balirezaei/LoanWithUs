using FluentAssertions;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common.ExtentionMethod;
using LoanWithUs.IntegrationTest.Utility;
using LoanWithUs.RestApi.Utility;
using LoanWithUs.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.IntegrationTest.CommandAuttomatedTests
{
    public class AdministratorLoginTest : IClassFixture<ToSqlTesting>
    {
        private readonly ToSqlTesting _toSqlTesting;

        public AdministratorLoginTest(ToSqlTesting toSqlTesting)
        {
            _toSqlTesting = toSqlTesting;
        }

        [Fact]
        public async Task Admin_should_throw_with_incorrect_info()
        {
            //Fixture
            var query = new AdminUserAttemptToLoginByUserNameCommand("admin", "admin");

            //Excersice
            Func<Task> act = () => _toSqlTesting.SendAsync(query);

            //Verification
            await act.Should().ThrowAsync<Exception>().WithMessage("User Not Found");
        }

        [Fact]
        public async Task Admin_should_receive_otp_code_with_correct_info()
        {
            //Fixture
            var query = new AdminUserAttemptToLoginByUserNameCommand("admin", "!2#4%6");

            //Excersice
            var result = await _toSqlTesting.SendAsync(query);

            //Verification
            result.key.Should().NotBe(Guid.Empty);
        }

        [Fact]
        public async Task Admin_With_SuccessfullLogin_AndValidOtp_Should_Get_JWT()
        {
            var userLogin = await _toSqlTesting.WithMockAdminAttempdToLogin();
            var vm = new ValidateAdministratorOTPViewModel()
            {
                code = userLogin.Code,
                key = userLogin.Key
            };
            var response = await _toSqlTesting.CallPostApi(vm, "/api/AdminLogin/ActivateCodeVerification");
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            var responseText = await response.Content.ReadAsStringAsync();
            var tokenService=_toSqlTesting.GetRequiredService<ITokenService>();
            var principal = tokenService.GetPrincipalFromExpiredToken(responseText);
            principal.Identity.Name.Should().Contain("admin");
        }


        
    }
}
