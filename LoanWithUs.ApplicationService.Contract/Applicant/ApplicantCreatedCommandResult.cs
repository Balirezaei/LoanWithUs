namespace LoanWithUs.ApplicationService.Contract
{
    public class ApplicantCreatedCommandResult
    {
        public int UserId { get; set; }

        public ApplicantCreatedCommandResult(int userId)
        {
            UserId = userId;
        }
    }
}