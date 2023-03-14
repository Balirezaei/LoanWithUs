using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{
    public class ApplicantCompleteBankInformationCommand : IRequest<ApplicantCompleteInformationCommandResult>
    {
        public int ApplicantId { get; set; }
        public string ShabaNumber { get; private set; }
        public string BankCartNumber { get; private set; }
        public BankType BankType { get; private set; }

    }
}