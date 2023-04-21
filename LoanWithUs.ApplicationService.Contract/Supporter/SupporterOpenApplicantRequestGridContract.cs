using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{
    public class SupporterOpenApplicantRequestGridContract : PagingContract, IRequest<List<ApplicantRequestGrid>>
    {
        public int SupporterId { get; set; }
    }
}
