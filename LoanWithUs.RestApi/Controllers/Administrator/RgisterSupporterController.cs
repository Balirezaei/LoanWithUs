using AutoMapper;
using LoanWithUs.ApplicationService.Contract.Administrator;
using LoanWithUs.Common.Enum;
using LoanWithUs.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LoanWithUs.RestApi.Controllers.Administrator
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = LoanRoleNames.Admin)]
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
        public async Task<IEnumerable<AdminRegisteredSupporterDto>> Get([FromQuery] AdminRegisteredSupporterVm vm)
        {
            var adminId = HttpContext.User.Claims.FirstOrDefault(m => m.Type == ClaimTypes.NameIdentifier).Value;
            var query = _mapper.Map<AdminRegisteredSupporterContract>(vm);
            return await _mediator.Send(query);
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
            var adminId = HttpContext.User.Claims.FirstOrDefault(m => m.Type == ClaimTypes.NameIdentifier).Value;
            var cmd = _mapper.Map<AdminRegisterSupporterCommand>(vm);

            cmd.AdminId = int.Parse(adminId);
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
