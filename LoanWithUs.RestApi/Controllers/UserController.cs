using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common.Enum;
using LoanWithUs.Common.ExtentionMethod;
using LoanWithUs.RestApi.Utility;
using LoanWithUs.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LoanWithUs.RestApi.Controllers.Applicant
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ITokenService _tokenService;
        public UserController(IMediator mediator, ITokenService tokenService)
        {
            _mediator = mediator;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserViewModel vm)
        {
            var command = new LoginUserCommand(vm.MobileNumber.ToMobileNumber());
            var res = await _mediator.Send(command);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> RequestNewActivateCode(RequestNewOTPCodeForUserViewModel vm)
        {
            var command = new RequestNewOTPCodeForUserCommand(vm.MobileNumber.ToMobileNumber());
            var res = await _mediator.Send(command);
            return Ok(res);
        }


        [HttpPost]
        public async Task<LoginResult> ActivateCodeVerification(ValidateUserOtpViewModel vm)
        {
            var query = new ValidateUserOtpQuery(vm.MobileNumber.ToMobileNumber(), vm.code);
            var res = await _mediator.Send(query);
            if (res.IsValid)
            {
                var usersClaims = new List<Claim>
                {
                    //new Claim(ClaimTypes.Name, res.FullName),
                    new Claim(ClaimTypes.NameIdentifier, res.UserId.ToString()),
                    new Claim(ClaimTypes.Role, res.RoleName)
                };

                var jwtToken = _tokenService.GenerateAccessToken(usersClaims);
                return new LoginResult(true, jwtToken);

            }
            else
            {
                return new LoginResult(res.IsValid, "");
            }

        }



    }
}
