using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{
    public class RequestNewOTPCodeForUserCommand :UserDataSecurityDate, IRequest<UserLoginCommandResult>
    {
        public RequestNewOTPCodeForUserCommand(string mobile)
        {
            Mobile = mobile;
        }

        public string Mobile { get; set; }
    }
}