using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common;
using LoanWithUs.Domain.UserAggregate;
using MediatR;

namespace LoanWithUs.ApplicationService
{
    public class CreateUserCommandHandler : IRequestHandler<CreateApplicantCommand, ApplicantCreatedCommandResult>
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IUnitOfWork _unitOfWork;

        public async Task<ApplicantCreatedCommandResult> Handle(CreateApplicantCommand request, CancellationToken cancellationToken)
        {
            var mobile = request.Mobile.StartsWith("09") ? "+98" + request.Mobile.Substring(2, request.Mobile.Length - 2) : request.Mobile;

            var applicant = new Applicant(mobile);
            await _applicantRepository.CreateApplicant(applicant);
            await _unitOfWork.CommitAsync();
            return new ApplicantCreatedCommandResult();
        }
    }
}