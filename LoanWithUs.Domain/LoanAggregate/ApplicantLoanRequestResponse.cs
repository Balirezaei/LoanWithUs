using LoanWithUs.Domain;

namespace LoanWithUs.Domain
{
    public class ApplicantLoanRequestResponse
    {
        public int Id { get; private set; }
        public ApplicantLoanRequestState State { get; private set; }
        public string Description { get; private set; }
        public LoanWithUsFile Attachment { get; set; }

        public ApplicantLoanRequestResponse(ApplicantLoanRequestState state, string description, LoanWithUsFile attachment = null)
        {
            State = state;
            Description = description;
            Attachment = attachment;
        }
    }

}
