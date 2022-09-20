using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{
    public class ApplicantCompleteEductionalInformationCommand : IRequest<ApplicantCompleteInformationCommandResult>
    {
        public int Id { get; set; }
        public string LastEducationLevel { get; set; }
        public string EducationalSubject { get; set; }

    }
}