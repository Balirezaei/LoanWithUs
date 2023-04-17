using AutoMapper;
using LoanWithUs.ApplicationService.Contract.Applicant;
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
    public class LoanRequestController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public LoanRequestController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public Task<ApplicantLoanRequestAvailability> GetLatestLoanRequestAvailability()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(m => m.Type == ClaimTypes.NameIdentifier).Value;

            return _mediator.Send(new GetApplicantLoanRequestAvailability(int.Parse(userId)));
        }

        [HttpPost]
        public Task<ApplicantRequestLoanResult> RequestNewLoan(ApplicantRequestLoanVm loanVm)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(m => m.Type == ClaimTypes.NameIdentifier).Value;
            var cmd = _mapper.Map<ApplicantRequestLoanCommand>(loanVm);
            cmd.ApplicantId = int.Parse(userId);
            return _mediator.Send(cmd);
        }
    }
}
