using LoanWithUs.Common.Enum;

namespace LoanWithUs.ApplicationService.Contract.Applicant
{
    public class CurrentApplicantLoanRequestFlow
    {
        public ApplicantLoanRequestState State { get; set; }
        public string StateDescription { get; set; }
        public string Description { get; set; }
        public string CreateDate { get; set; }
    }

}
