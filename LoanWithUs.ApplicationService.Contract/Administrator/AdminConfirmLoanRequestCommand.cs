using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{
    public class AdminConfirmLoanRequestCommand : IRequest<AdminRejectLoanRequestResult>
    {
        public int LoanRequestId { get; set; }
        public int AdminId { get; set; }
    }

    public class AdminPayLoanRequestCommand : IRequest<AdminPayLoanRequestResult>
    {
        public int LoanRequestId { get; set; }
        public int AdminId { get; set; }
        public int FileId { get; set; }
    }

    public class AdminPayLoanRequestResult
    {

    }

}