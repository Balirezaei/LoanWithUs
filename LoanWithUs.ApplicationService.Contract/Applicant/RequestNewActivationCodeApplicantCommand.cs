using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{
    public class RequestNewActivationCodeApplicantCommand : IRequest<ApplicantCreatedCommandResult>
    {
        public string Mobile { get; set; }
    }
}