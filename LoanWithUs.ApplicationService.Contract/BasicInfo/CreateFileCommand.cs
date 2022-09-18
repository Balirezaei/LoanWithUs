using LoanWithUs.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace LoanWithUs.ApplicationService.Contract
{
    public class CreateFileCommand : IRequest<CreateFileCommandResult>
    {
        public IFormFile File { get; set; }
        public FileType FileType { get; set; }
    }
   
    public class RemoveFileByIdCommand : IRequest
    {
        public int Id { get; set; }
    }
}