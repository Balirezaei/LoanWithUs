namespace LoanWithUs.ApplicationService.Contract
{
    public class UserLoginCommandResult
    {
        public int UserId { get; set; }

        public UserLoginCommandResult(int userId)
        {
            UserId = userId;
        }
    }
}