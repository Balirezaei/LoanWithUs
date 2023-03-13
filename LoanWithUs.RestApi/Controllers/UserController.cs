using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.ViewModel;
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
        public async Task<IActionResult> Login(LoginUserViewModel vm)
        {
            var command = new LoginUserCommand(vm.MobileNumber);
            var res = await _mediator.Send(command);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> RequestNewActivateCode(RequestNewOTPCodeForUserViewModel vm)
        {
            var command = new RequestNewOTPCodeForUserCommand(vm.MobileNumber);
            var res = await _mediator.Send(command);
            return Ok(res);
        }


        [HttpPost]
        public async Task<IActionResult> ActivateCodeVerification(ValidateUserOtpViewModel vm)
        {
            var query = new ValidateUserOtpQuery(vm.MobileNumber, vm.code);
            var res = await _mediator.Send(query);
            return Ok(res);
        }



    }
}
