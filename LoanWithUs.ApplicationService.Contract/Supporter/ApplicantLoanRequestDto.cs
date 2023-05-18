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
        public string Description { get; set; }
        public string TrackingNumber { get; set; }
        public string CreateDate { get; set; }
    }
    public class GetSupporterApplicantsActiveLoan :IRequest<List<SupporterApplicantsActiveLoanDto>>
    {
        public int SupporterId { get; set; }
    }
    public class SupporterApplicantsActiveLoanDto
    {
        public int SerialNumber { get; private set; }
        public string WageAmount { get; set; }
        public string Amount { get; set; }
        public string RemainingAmount { get; set; }
        public string StartDate { get; set; }
        public string ApplicantFullName { get; set; }
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
