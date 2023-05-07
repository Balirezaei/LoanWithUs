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
        public string Description { get; set; }
        public ApplicantAvailabileLoanDetail ApplicantAvailabileLoanDetail { get; set; }
    }

    public class ApplicantAvailabileLoanDetail
    {
        public int MaxLoanAmount { get; set; }
        public int[] Installments { get; set; }
    }
}
