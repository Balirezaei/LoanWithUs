using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{
    public class CreateApplicantCommand: IRequest<ApplicantCreatedCommandResult>
    {
        public string Mobile { get; set; }
    }

    public class ValidateUserActivationCodeQuery: IRequest<ValidateUserActivationCodeQueryResult>
    {
        public string Mobile { get; set; }
        public string code { get; set; }
    }

    public class ValidateUserActivationCodeQueryResult
    {
        public bool IsValid { get; set; }
    }
}