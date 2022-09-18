using LoanWithUs.ApplicationService.Contract;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanWithUs.RestApi.Controllers.LoanWithUsFile
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoanWithUsFileController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoanWithUsFileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public Task<CreateFileCommandResult> UploadFile([FromForm] CreateFileCommand cmd)
        {
            return _mediator.Send(cmd);
        }

        [HttpGet]
        public Task<FileDto> GetFile(int id)
        {
            return _mediator.Send(new GetFileByIdQuery() { Id = id });
        }

        [HttpGet]
        public Task RemoveFile(int id)
        {
            return _mediator.Send(new RemoveFileByIdCommand() { Id = id });
        }
    }
}
