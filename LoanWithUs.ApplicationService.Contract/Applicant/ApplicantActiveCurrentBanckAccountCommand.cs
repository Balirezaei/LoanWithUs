using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{
    public class ApplicantActiveCurrentBanckAccountCommand : IRequest<ApplicantCompleteInformationCommandResult>
    {
        public int ApplicantId { get; set; }
        public string ShabaNumber { get; private set; }
    }


}