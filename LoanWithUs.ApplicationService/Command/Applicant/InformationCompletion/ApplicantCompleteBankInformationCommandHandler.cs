using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common;
using LoanWithUs.Domain.UserAggregate;
using LoanWithUs.Exceptions;
using MediatR;

namespace LoanWithUs.ApplicationService.Command
{
    public class ApplicantCompleteBankInformationCommandHandler : IRequestHandler<ApplicantCompleteBankInformationCommand, ApplicantCompleteInformationCommandResult>
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IApplicantReadRepository _applicantReadRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ApplicantCompleteBankInformationCommandHandler(IApplicantRepository applicantRepository, IApplicantReadRepository applicantReadRepository, IUnitOfWork unitOfWork)
        {
            _applicantRepository = applicantRepository;
            _applicantReadRepository = applicantReadRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApplicantCompleteInformationCommandResult> Handle(ApplicantCompleteBankInformationCommand request, CancellationToken cancellationToken)
        {
            var applicant = await _applicantReadRepository.FindApplicantByIdIncludeEducationalInformation(request.ApplicantId);
            if (applicant == null)
                throw new NotFoundException("چنین درخواستگری موجود نیست!");


            applicant.UpdateBankInformation(new BankAccountInformation("", ""))

        }




    }
}