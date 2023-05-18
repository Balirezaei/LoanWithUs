using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common.Enum;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LoanWithUs.RestApi.Controllers.Supporter
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = LoanRoleNames.Supporter)]
    public class SupportedApplicantLoanController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SupportedApplicantLoanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HttpGet]
        public Task<List<SupporterApplicantsActiveLoanDto>> GetActiveLoan()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(m => m.Type == ClaimTypes.NameIdentifier).Value;
            return _mediator.Send(new GetSupporterApplicantsActiveLoan() { SupporterId = int.Parse(userId) });
        }

    }
}
