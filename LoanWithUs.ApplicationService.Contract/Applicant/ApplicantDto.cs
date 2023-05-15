using LoanWithUs.Common;
using LoanWithUs.Common.DefinedType;
using LoanWithUs.Common.Enum;
using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{
    public class ApplicantDto
    {
        public EducationLevel LastEducationLevel { get; set; }
        public string EducationalSubject { get; set; }
    }

    public class GetApplicantDashboardQuery : IRequest<ApplicantDashboard>
    {
        public int ApplicantId { get; set; }
    }

    public class ApplicantDashboard
    {
        public int CurrentLadder { get; set; }
        public bool ActiveLoan { get; set; }
    }

    public class ApplicantAvailableLoanInitDto
    {
        public Amount Amount { get; set; }
    }

    public class LoanRequestPrerequisite
    {
        public int LadderStep { get; set; }
        public Amount AvailableAmount { get; set; }
        public int AvailableInstallments { get; set; }
        public bool CanRequestLoan { get; set; }
        public ApplicantLoanRequestState LoanRequestState { get; set; }
    }

}