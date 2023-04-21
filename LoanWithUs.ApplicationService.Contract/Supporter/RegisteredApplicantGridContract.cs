using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{
    public class RegisteredApplicantGridContract : PagingContract, IRequest<List<RegisteredApplicantDto>>
    {
        public int SupporterId { get; set; }
    }
}
