using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LoanWithUs.IntegrationTest.Utility.Authorization
{
    public class BasicAuthenticationHandler : AuthenticationHandler<BasicTestAuthenticationOptions>
    {
        private readonly TestUserLogined _testUser;



        public BasicAuthenticationHandler(
            IOptionsMonitor<BasicTestAuthenticationOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock, TestUserLogined testUser) : base(options, logger, encoder, clock)
        {
            _testUser = testUser;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            //if (Request.Path.Value.ToLower().Contains("/api/account/") || Request.Path.Value.ToLower().Contains("/favicon.ico"))
            //{
            //    return AuthenticateResult.NoResult();
            //}

            if (Request.Path.Value.ToLower().Contains("/api/adminlogin/activatecodeverification"))
            {
                return AuthenticateResult.NoResult();
            }


            if (_testUser == null)
            {
                return AuthenticateResult.Fail("Not Authenticated");
            }
            var claims = new[]
         {
              //  new Claim(ClaimTypes.Role, RoleNames.GetName(_testUser.OrmsRole)),
                new Claim(ClaimTypes.Role, _testUser.Role.ToString()),
                new Claim(ClaimTypes.NameIdentifier, _testUser.UserId.ToString())
            };

            //{
            //    new Claim(ClaimTypes.Name, res.FullName),
            //        new Claim(ClaimTypes.NameIdentifier, res.UserId.ToString()),
            //        new Claim(ClaimTypes.Role, LoanRole.Admin.ToString())
            //var mockToken = MockJwtTokens.GenerateJwtToken(claims_Jwt);

            //var ssoToken = _ssoHelper.DecodeToken(mockToken);



            //var claims = new[]
            //{
            //    new Claim(ClaimTypes.Role, RoleNames.GetName(_testUser.OrmsRole)),
            //    new Claim("NationalCode", _testUser.NationalCode)
            //};

            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, Scheme.Name));

            var authenticationTicket = new AuthenticationTicket(claimsPrincipal,
                new AuthenticationProperties { IsPersistent = false },
                Scheme.Name
            );

            return AuthenticateResult.Success(authenticationTicket);
        }

    }

}
