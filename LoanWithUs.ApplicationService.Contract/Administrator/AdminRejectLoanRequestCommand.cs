using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{
    public class AdminRejectLoanRequestCommand : IRequest<AdminRejectLoanRequestResult>
    {
        public int LoanRequestId { get; set; }
        public int AdminId { get; set; }
        public string Reason { get; set; }
    }

    public class AdminRejectLoanRequestResult
    {

    }

}