using LoanWithUs.Common.Enum;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanWithUs.RestApi.Controllers.Applicant
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = LoanRoleNames.Applicant)]
    public class LoanRequestController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LoanRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public void GetLatestLoanStatus()
        {

        }
        
        [HttpPost]
        public void RequestNewLoan()
        {

        }
    }
}
