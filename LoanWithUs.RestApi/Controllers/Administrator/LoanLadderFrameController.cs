using AutoMapper;
using LoanWithUs.ApplicationService.Contract.Administrator;
using LoanWithUs.Common.Enum;
using LoanWithUs.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoanWithUs.RestApi.Controllers.Administrator
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = LoanRoleNames.Admin)]
    public class LoanLadderFrameController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public LoanLadderFrameController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public Task<List<LoanLadderFrameDto>> Get([FromQuery] LoanLadderFrameContractGridContractVm vm)
        {
            var query = _mapper.Map<LoanLadderFrameContractGridContract>(vm);
            return _mediator.Send(query);
        }

        //// GET api/<LoanLadderFrameController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}


        [HttpPost]
        public Task<LoanLadderFrameCreateCommandResult> Post([FromBody] LoanLadderFrameCreateCommand cmd)
        {
            var query = _mapper.Map<LoanLadderFrameCreateCommand>(cmd);
            return _mediator.Send(query);
        }

        [HttpPost]
        public Task AppendInstallment([FromBody] LoanLadderFrameAppendInstallmentCommand cmd)
        {
            return _mediator.Send(cmd);
        }

        //// PUT api/<LoanLadderFrameController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<LoanLadderFrameController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
