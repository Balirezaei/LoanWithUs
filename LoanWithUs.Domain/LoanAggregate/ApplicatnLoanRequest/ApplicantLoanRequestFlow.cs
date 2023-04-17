using LoanWithUs.Common.Enum;

namespace LoanWithUs.Domain
{
    public class ApplicantLoanRequestFlow
    {
        public int Id { get; private set; }
        public ApplicantLoanRequestState State { get; private set; }
        public string Description { get; private set; }
       
        public DateTime CreateDate { get; set; }

        public ApplicantLoanRequestFlow(ApplicantLoanRequestState state, string description)
        {
            State = state;
            Description = description;
            CreateDate = DateTime.Now;
        }
    }

}
