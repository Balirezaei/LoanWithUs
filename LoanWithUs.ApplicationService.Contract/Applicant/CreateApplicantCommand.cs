using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{
    public class CreateApplicantCommand : IRequest<ApplicantCreatedCommandResult>
    {
        public string Mobile { get; set; }
    }
}