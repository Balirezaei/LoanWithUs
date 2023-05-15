using LoanWithUs.Common.DefinedType;

namespace LoanWithUs.ApplicationService.Contract.Applicant
{
    public class CurrentApplicantLoanRequestDetail
    {
        public string Reason { get; set; }
        public string Description { get; set; }
        public string Amount { get; set; }
        public int InstallmentsCount { get; set; }
        public string LastStateDescription { get; set; }
        public List<CurrentApplicantLoanRequestFlow> Flows { get; set; }
    }

}
