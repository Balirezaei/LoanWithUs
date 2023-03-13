using LoanWithUs.Common.DefinedType;
using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{
    public class LoginUserCommand : UserDataSecurityDate , IRequest<UserLoginCommandResult>
    {
        public LoginUserCommand(MobileNumber mobile)
        {
            MobileNumber = mobile;
        }

        public MobileNumber MobileNumber { get; set; }
    }
}