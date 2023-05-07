using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{
    public class SupporterOpenApplicantRequestCountContract : IRequest<TotalGrid>
    {
        public int SupporterId { get; set; }
    }
}
