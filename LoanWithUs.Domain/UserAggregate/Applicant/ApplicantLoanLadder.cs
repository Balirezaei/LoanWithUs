using LoanWithUs.Common;

namespace LoanWithUs.Domain
{
    public class ApplicantLoanLadder
    {
        public int Id { get; set; }
        public LoanLadderFrame LoanLadderFrame { get; set; }
        public int LoanLaddrFrameId { get; set; }

        public DateTime CreateDate { get; set; }
        public string Description { get; set; }

        protected ApplicantLoanLadder()
        {
        }

        public ApplicantLoanLadder(int loanLaddrFrameId, string description, IDateTimeServiceProvider dateProvider)
        {
            LoanLaddrFrameId = loanLaddrFrameId;
            Description = description;
            CreateDate = dateProvider.GetDate();
        }
    }

}