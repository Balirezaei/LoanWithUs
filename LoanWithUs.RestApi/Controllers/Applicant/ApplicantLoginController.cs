using LoanWithUs.ApplicationService.Contract;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanWithUs.RestApi.Controllers.Applicant
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApplicantLoginController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ApplicantLoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login(CreateApplicantCommand command) {
            var res = await _mediator.Send(command);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> RequestNewActivateCode(RequestNewActivationCodeApplicantCommand command)
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
