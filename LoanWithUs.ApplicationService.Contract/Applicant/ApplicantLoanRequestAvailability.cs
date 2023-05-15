using MediatR;

namespace LoanWithUs.ApplicationService.Contract.Applicant
{
    public class GetApplicantLoanRequestAvailability : IRequest<ApplicantLoanRequestAvailability>
    {
        public GetApplicantLoanRequestAvailability(int applicantId)
        {
            ApplicantId = applicantId;
        }

        public int ApplicantId { get; set; }
    }

    public class ApplicantLoanRequestAvailability
    {
        public bool CanRequestALoan { get; set; }
        public NotAvailableResonType NotAvailableResonType { get; set; }
        public string Description { get; set; }
        public ApplicantAvailabileLoanDetail ApplicantAvailabileLoanDetail { get; set; }

    }
    public enum NotAvailableResonType
    {
        NotConfirmedProfile=1,
        HasOpenRequest=2,
        HasNotSettelledLoan=3
    }

    public class ApplicantAvailabileLoanDetail
    {
        public int MaxLoanAmount { get; set; }
        public int[] Installments { get; set; }
    }
}
