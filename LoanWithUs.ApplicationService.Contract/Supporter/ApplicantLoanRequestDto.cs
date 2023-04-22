using LoanWithUs.Common.Enum;
using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{
    public class ApplicantLoanRequestDto
    {
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        public string ApplicantFullName { get; set; }
        public ApplicantLoanRequestState State { get; set; }
        public int Amount { get; set; }
        public int InstallmentCount { get; set; }
        public string Reason { get; set; }
        public string TrackingNumber { get; set; }
        public string CreateDate { get; set; }
    }
    
    public class SupporterConfirmLoanRequestCommand : IRequest <SupporterConfirmLoanRequestResult>
    {
        public int LoanRequestId { get; set; }
        public int SupporterId { get; set; }
    }

    public class SupporterConfirmLoanRequestResult
    {

    }

    public class SupporterRejectLoanRequestCommand : IRequest<SupporterRejectLoanRequestResult>
    {
        public int LoanRequestId { get; set; }
        public int SupporterId { get; set; }
    }

    public class SupporterRejectLoanRequestResult
    {

    }
}
