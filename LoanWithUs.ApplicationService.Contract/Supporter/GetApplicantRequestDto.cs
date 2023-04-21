using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{
    public class GetApplicantRequestDto : IRequest<ApplicantLoanRequestDto>
    {
        public int SupporterId { get; set; }
        public int ApplicantId { get; set; }
        public int RequestId { get; set; }
    }

}
