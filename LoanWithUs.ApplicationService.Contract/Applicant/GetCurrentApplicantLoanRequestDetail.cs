using MediatR;

namespace LoanWithUs.ApplicationService.Contract.Applicant
{
    public class GetCurrentApplicantLoanRequestDetail : IRequest<CurrentApplicantLoanRequestDetail>
    {
        public int ApplicantId { get; set; }
    }

}
