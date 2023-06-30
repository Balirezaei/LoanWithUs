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

    public class ApplicantPersonalInformationCommand : IRequest<ApplicantCompleteInformationCommandResult>
    {
        public int ApplicantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MotherFullName { get; set; }
        public string FatherFullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string IdentityNumber { get; set; }
        public string Job { get; set; }
        public bool IsMale { get; set; }
        public bool IsMarried { get; set; }
        public int ChildrenCount { get; set; }
        public int MinimumIncome { get; set; }

    }
}