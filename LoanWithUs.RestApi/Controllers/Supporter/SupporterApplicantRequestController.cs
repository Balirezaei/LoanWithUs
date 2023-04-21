using AutoMapper;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common.Enum;
using LoanWithUs.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LoanWithUs.RestApi.Controllers.Supporter
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = LoanRoleNames.Supporter)]
    public class SupporterApplicantRequestController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SupporterApplicantRequestController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<PagedListResult<ApplicantRequestGrid>> GetOpenRequests([FromQuery] ApplicantOpenRequestGridVm vm)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(m => m.Type == ClaimTypes.NameIdentifier).Value;
            var query = _mapper.Map<SupporterOpenApplicantRequestGridContract>(vm);

            query.SupporterId = int.Parse(userId);

            var list = await _mediator.Send(query);
            var count = await _mediator.Send(query);

            return new PagedListResult<ApplicantRequestGrid>()
            {
                List = list,
                TotalCount = count.Count,
                PageNumber = vm.PageNumber,
                PageSize = vm.PageSize,
            };
            
        }

        //[HttpGet]
        //public Task<ApplicantLoanRequestDto> ViewDetails(int id)
        //{

        //}

    }

}
