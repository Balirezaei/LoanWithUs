using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common.Enum;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LoanWithUs.RestApi.Controllers.Applicant
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = LoanRoleNames.Applicant)]
    public class ApplicantDashboardController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ApplicantDashboardController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public Task<ApplicantDashboard> GetInfo()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(m => m.Type == ClaimTypes.NameIdentifier).Value;
            return _mediator.Send(new GetApplicantDashboardQuery() { ApplicantId = int.Parse(userId) });
        }

    }
}
