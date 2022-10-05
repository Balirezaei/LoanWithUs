using LoanWithUs.Common;
using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{
    public class ApplicantCompleteEductionalInformationCommand : IRequest<ApplicantCompleteInformationCommandResult>
    {
        public int ApplicantId { get; set; }
        public EducationLevel LastEducationLevel { get; set; }
        public string EducationalSubject { get; set; }

    }
}