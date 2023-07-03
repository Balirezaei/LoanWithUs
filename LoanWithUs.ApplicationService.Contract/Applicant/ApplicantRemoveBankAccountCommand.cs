using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{
    public class ApplicantRemoveBankAccountCommand : IRequest<ApplicantCompleteInformationCommandResult>
    {
        public int ApplicantId { get; set; }
        public string ShabaNumber { get; private set; }
    }
    
}