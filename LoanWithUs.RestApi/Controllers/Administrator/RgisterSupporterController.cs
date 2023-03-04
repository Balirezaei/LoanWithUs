using AutoMapper;
using LoanWithUs.ApplicationService.Contract.Administrator;
using LoanWithUs.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanWithUs.RestApi.Controllers.Administrator
{
    [Route("api/[controller]")]
    [ApiController]
    public class RgisterSupporterController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public RgisterSupporterController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IEnumerable<AdminRegisteredSupporterDto>> Get(AdminRegisteredSupporterContract contract)
        {
            return await _mediator.Send(contract);
        }


        //// GET api/<ValuesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}


        [HttpPost]
        public async Task Post([FromBody] AdminRegisterSupporterVm vm)
        {
            var cmd = _mapper.Map<AdminRegisterSupporterCommand>(vm);
            await _mediator.Send(cmd);
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
