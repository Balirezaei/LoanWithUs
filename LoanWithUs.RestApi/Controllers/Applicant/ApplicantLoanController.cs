using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common.Enum;
using LoanWithUs.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LoanWithUs.RestApi.Controllers.Applicant
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = LoanRoleNames.Applicant)]
    public class ApplicantLoanController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApplicantLoanController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public Task<ActiveApplicantLoan> GetActiveLoan()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(m => m.Type == ClaimTypes.NameIdentifier).Value;

            return _mediator.Send(new GetActiveApplicantLoan() { ApplicantId = int.Parse(userId) });
        }

        [HttpPost]
        public Task<ApplicantPaymentResult> PayInstallment(ApplicantInstallmentPaymentVm vm)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(m => m.Type == ClaimTypes.NameIdentifier).Value;

            return _mediator.Send(new ApplicantInstallmentPaymentCommand() { ApplicantId = int.Parse(userId),UniqueIdentity=vm.UniqueIdentity });
        }
    }
}
