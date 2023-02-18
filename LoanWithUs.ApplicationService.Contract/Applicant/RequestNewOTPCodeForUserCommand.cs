using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{
    public class RequestNewOTPCodeForUserCommand :UserDataSecurityِate, IRequest<UserLoginCommandResult>
    {
        public RequestNewOTPCodeForUserCommand(string mobile)
        {
            Mobile = mobile;
        }

        public string Mobile { get; set; }
    }
}