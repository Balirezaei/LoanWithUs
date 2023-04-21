using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{
    public class SupporterOpenApplicantRequestCountContract : PagingContract, IRequest<TotalGrid>
    {
        public int SupporterId { get; set; }
    }
}
