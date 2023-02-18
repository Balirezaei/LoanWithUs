namespace LoanWithUs.ApplicationService.Contract
{
    public class UserLoginCommandResult : RequestOtpResult
    {
        public int UserId { get; set; }

        public UserLoginCommandResult(int userId, Guid code) : base(code)
        {
            UserId = userId;
        }
    }
}