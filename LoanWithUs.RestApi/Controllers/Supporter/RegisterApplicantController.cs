using AutoMapper;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common.Enum;
using LoanWithUs.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LoanWithUs.RestApi.Controllers.Supporter
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = LoanRoleNames.Supporter)]
    public class RegisterApplicantController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public RegisterApplicantController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<PagedListResult<RegisteredApplicantDto>> Get([FromQuery] RegisteredApplicantGridVm vm)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(m => m.Type == ClaimTypes.NameIdentifier).Value;
            var query = _mapper.Map<RegisteredApplicantGridContract>(vm);
            query.SupporterId = int.Parse(userId);
            
            var list = await _mediator.Send(query);
            var count = await _mediator.Send(new RegisteredApplicantCountContract { SupporterId=query.SupporterId});
            
            return new PagedListResult<RegisteredApplicantDto>()
            {
                List = list,
                TotalCount = count.Count,
                PageNumber = vm.PageNumber,
                PageSize = vm.PageSize,
            };
        }


        //// GET api/<ValuesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}


        [HttpPost]
        public async Task<SupporterRegistereApplicantCammandResult> Post([FromBody] SupporterRegistereApplicantVm vm)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(m => m.Type == ClaimTypes.NameIdentifier).Value;
            var cmd = _mapper.Map<SupporterRegistereApplicantCommand>(vm);

            cmd.SupporterId = int.Parse(userId);
            return await _mediator.Send(cmd);
        }

        //// PUT api/<ValuesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}


    }
}