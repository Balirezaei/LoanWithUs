using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{
    public class AdminUserAttemptToLoginByUserNameCommand :UserDataSecurityDate, IRequest<AdminRequestOtpResult>
    {
        public AdminUserAttemptToLoginByUserNameCommand(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName { get; set; }
        public string Password { get; set; }

    }
}