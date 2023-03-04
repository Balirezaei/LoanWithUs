using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{
    public class LoginUserCommand : UserDataSecurityDate , IRequest<UserLoginCommandResult>
    {
        public LoginUserCommand(string mobile)
        {
            Mobile = mobile;
        }

        public string Mobile { get; set; }
    }
}