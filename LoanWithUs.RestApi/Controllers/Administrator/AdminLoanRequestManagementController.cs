using AutoMapper;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common.Enum;
using LoanWithUs.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LoanWithUs.RestApi.Controllers.Administrator
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = LoanRoleNames.Admin)]
    public class AdminLoanRequestManagementController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AdminLoanRequestManagementController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<PagedListResult<AdminApplicantRequestGrid>> GetApplicantOpenRequests([FromQuery] ApplicantOpenRequestGridVm vm)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(m => m.Type == ClaimTypes.NameIdentifier).Value;
            var query = _mapper.Map<AdminOpenApplicantRequestGridContract>(vm);

            var list = await _mediator.Send(query);
            var count = await _mediator.Send(new AdminOpenApplicantRequestCountContract());

            return new PagedListResult<AdminApplicantRequestGrid>()
            {
                List = list,
                TotalCount = count.Count,
                PageNumber = vm.PageNumber,
                PageSize = vm.PageSize,
            };
        }

        [HttpPost]
        public async Task<AdminRejectLoanRequestResult> ConfirmRequest(AdminLoanRequestAcceptViewModel vm)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(m => m.Type == ClaimTypes.NameIdentifier).Value;
            return await _mediator.Send(new AdminConfirmLoanRequestCommand()
            {
                AdminId = int.Parse(userId),
                LoanRequestId = vm.RequestId
            });
        }

        [HttpPost]
        public async Task<AdminRejectLoanRequestResult> RejectRequest(AdminLoanRequestRejectViewModel vm)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(m => m.Type == ClaimTypes.NameIdentifier).Value;
            return await _mediator.Send(new AdminRejectLoanRequestCommand()
            {
                AdminId = int.Parse(userId),
                LoanRequestId = vm.RequestId,
                Reason = vm.Reason
            });
        }

        [HttpPost]
        public async Task<AdminPayLoanRequestResult> PayRequest(AdminPayLoanRequestViewModel vm)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(m => m.Type == ClaimTypes.NameIdentifier).Value;
            return await _mediator.Send(new AdminPayLoanRequestCommand()
            {
                AdminId = int.Parse(userId),
                LoanRequestId = vm.RequestId,
                FileId = vm.FileId
            });
        }

    }
}