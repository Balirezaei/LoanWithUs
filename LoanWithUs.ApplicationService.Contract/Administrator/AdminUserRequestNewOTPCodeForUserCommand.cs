using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{
    public class AdminUserRequestNewOTPCodeForUserCommand : UserDataSecurityِate, IRequest<AdminRequestOtpResult>
    {
   
        public int AdminId { get; set; }

        public AdminUserRequestNewOTPCodeForUserCommand(int userId)
        {
            AdminId = userId;
        }
    }


}