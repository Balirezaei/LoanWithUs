using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common.Enum;
using LoanWithUs.Domain;
using LoanWithUs.RestApi.Utility;
using LoanWithUs.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LoanWithUs.RestApi.Controllers.Administrator
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    //[Authorize(Roles = LoanRoleNames.Admin)]
    public class AdminLoginController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ITokenService _tokenService;

        public AdminLoginController(IMediator mediator, ITokenService tokenService)
        {
            _mediator = mediator;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(AdminUserGetByUserNameViewModel vm)
        {
            var command = new AdminUserAttemptToLoginByUserNameCommand(vm.UserName, vm.Password);
            var res = await _mediator.Send(command);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> RequestNewActivateCode(
            AdminUserRequestNewOTPCodeForUserViewModel vm
        )
        {
            var command = new AdminUserRequestNewOTPCodeForUserCommand(vm.AdminId);
            var res = await _mediator.Send(command);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> ActivateCodeVerification(
            ValidateAdministratorOTPViewModel vm
        )
        {
            var query = new ValidateAdministratorOTPQuery(vm.key, vm.code);
            AdministratorOTPValidationResult res = await _mediator.Send(query);
            if (res.IsValid)
            {
                var usersClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, res.FullName),
                    new Claim(ClaimTypes.NameIdentifier, res.UserId.ToString()),
                    new Claim(ClaimTypes.Role, LoanRoleNames.Admin)
                };

                var jwtToken = _tokenService.GenerateAccessToken(usersClaims);
                var result = new LoginResult(true, jwtToken);
                return Ok(result);
            }
            else
            {
                var result = new LoginResult(false, "");
                return Ok(result);
            }
        }
    }
}
