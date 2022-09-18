using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{
    public class GetFileByIdQuery : IRequest<FileDto>
    {
        public int Id { get; set; }
    }
}