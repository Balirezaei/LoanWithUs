using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{
    public class GetActiveApplicantLoan : IRequest<ActiveApplicantLoan>
    {
        public int ApplicantId { get; set; }
    }

}