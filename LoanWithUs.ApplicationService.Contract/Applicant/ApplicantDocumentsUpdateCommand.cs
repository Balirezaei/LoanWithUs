using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{
    public class ApplicantDocumentsUpdateCommand : IRequest<ApplicantCompleteInformationCommandResult>
    {
       public int ApplicantId { get; set; }
        public int[] FileId { get; set; }
    }
}