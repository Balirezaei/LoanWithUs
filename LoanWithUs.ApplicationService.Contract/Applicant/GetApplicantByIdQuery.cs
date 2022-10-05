using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{
    public class GetApplicantByIdQuery : IRequest<ApplicantDto>
    {
        public int ApplicantId { get; set; }
    }
}