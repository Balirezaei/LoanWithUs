using LoanWithUs.Common;
using LoanWithUs.Common.Enum;

namespace LoanWithUs.Domain
{
    public class ApplicantLoanRequestFlow
    {
        public int Id { get; private set; }
        public ApplicantLoanRequestState State { get; private set; }
        public string Description { get; private set; }
       
        public DateTime CreateDate { get; set; }

        protected ApplicantLoanRequestFlow()
        {
        }

        public ApplicantLoanRequestFlow(ApplicantLoanRequestState state, string description, IDateTimeServiceProvider dateProvider)
        {
            State = state;
            Description = description;
            CreateDate = dateProvider.GetDate();
        }
    }

}
