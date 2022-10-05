using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common;
using LoanWithUs.Domain.UserAggregate;
using LoanWithUs.Exceptions;
using MediatR;

namespace LoanWithUs.ApplicationService.Command
{
    public class RequestNewActivationCodeApplicantCommandHandler : IRequestHandler<RequestNewActivationCodeApplicantCommand, ApplicantCreatedCommandResult>
    {
        private readonly IApplicantReadRepository _applicantReadRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RequestNewActivationCodeApplicantCommandHandler(IApplicantRepository applicantRepository, IUnitOfWork unitOfWork, IApplicantReadRepository applicantReadRepository, IApplicantDomainService applicantDomainService)
        {
            _unitOfWork = unitOfWork;
            _applicantReadRepository = applicantReadRepository;
        }
        public async Task<ApplicantCreatedCommandResult> Handle(RequestNewActivationCodeApplicantCommand request, CancellationToken cancellationToken)
        {
            var applicant = await _applicantReadRepository.FindApplicantByMobile(request.Mobile);
            if (applicant == null)
            {
                throw new NotFoundException("شماره موبایل نامعتبر!");
            }

            applicant.AddNewLogin();
            await _unitOfWork.CommitAsync();

            return new ApplicantCreatedCommandResult(applicant.Id);
        }
    }
}