using LoanWithUs.ApplicationService.Contract;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanWithUs.RestApi.Controllers.Applicant
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserCommand command) {
            var res = await _mediator.Send(command);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> RequestNewActivateCode(RequestNewOTPCodeForUserCommand command)
        {
            var res = await _mediator.Send(command);
            return Ok(res);
        }


        [HttpPost]
        public async Task<IActionResult> ActivateCodeVerification(ValidateUserActivationCodeQuery command)
        {
            var res = await _mediator.Send(command);
            return Ok(res);
        }

        

    }
}
