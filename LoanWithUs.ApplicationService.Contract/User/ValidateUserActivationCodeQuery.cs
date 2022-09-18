using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{
    public class ValidateUserActivationCodeQuery : IRequest<ValidateUserActivationCodeQueryResult>
    {
        public string Mobile { get; set; }
        public string code { get; set; }
    }
}