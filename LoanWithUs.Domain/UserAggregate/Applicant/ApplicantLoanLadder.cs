namespace LoanWithUs.Domain
{
    public class ApplicantLoanLadder
    {
        public int Id { get; set; }
        public LoanLadderFrame LoanLadderFrame { get; set; }
        public int LoanLaddrFrameId { get; set; }

        public DateTime CreateDate { get; set; }
        public string Description { get; set; }

        public ApplicantLoanLadder(int loanLaddrFrameId, string description)
        {
            LoanLaddrFrameId = loanLaddrFrameId;
            Description = description;
            CreateDate = DateTime.Now;
        }
    }

}