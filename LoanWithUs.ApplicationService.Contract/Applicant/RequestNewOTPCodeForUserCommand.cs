using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{
    public class RequestNewOTPCodeForUserCommand : IRequest<UserLoginCommandResult>
    {
        public string Mobile { get; set; }
    }
}