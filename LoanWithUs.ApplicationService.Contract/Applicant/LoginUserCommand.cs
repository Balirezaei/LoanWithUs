using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{
    public class LoginUserCommand : IRequest<UserLoginCommandResult>
    {
        public string Mobile { get; set; }
    }
}