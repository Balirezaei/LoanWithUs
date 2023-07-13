using LoanWithUs.Common;
using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{
    public class ApplicantAddBankInformationDto
    {
        public string ShabaNumber { get; private set; }
        public string BankCartNumber { get; private set; }
        public BankType BankType { get; private set; }
        public bool IsActive { get; set; }
    }
    public class ApplicantAddBankInformationCommand : ApplicantAddBankInformationDto, IRequest<ApplicantCompleteInformationCommandResult>
    {
        public int ApplicantId { get; set; }
      
    }
}