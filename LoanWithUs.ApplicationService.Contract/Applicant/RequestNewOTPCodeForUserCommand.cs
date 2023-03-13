using LoanWithUs.Common.DefinedType;
using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{
    public class RequestNewOTPCodeForUserCommand :UserDataSecurityDate, IRequest<UserLoginCommandResult>
    {
        public RequestNewOTPCodeForUserCommand(MobileNumber mobile)
        {
            MobileNumber = mobile;
        }

        public MobileNumber MobileNumber { get; set; }
    }
}