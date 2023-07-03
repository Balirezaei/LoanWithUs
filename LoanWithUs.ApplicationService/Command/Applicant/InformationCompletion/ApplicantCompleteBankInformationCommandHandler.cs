using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common;
using LoanWithUs.Domain;
using LoanWithUs.Exceptions;
using MediatR;

namespace LoanWithUs.ApplicationService.Command
{
    public class ApplicantAddBankInformationCommandHandler : IRequestHandler<ApplicantAddBankInformationCommand, ApplicantCompleteInformationCommandResult>
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IApplicantReadRepository _applicantReadRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ApplicantAddBankInformationCommandHandler(IApplicantRepository applicantRepository, IApplicantReadRepository applicantReadRepository, IUnitOfWork unitOfWork)
        {
            _applicantRepository = applicantRepository;
            _applicantReadRepository = applicantReadRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApplicantCompleteInformationCommandResult> Handle(ApplicantAddBankInformationCommand request, CancellationToken cancellationToken)
        {
            var applicant = await _applicantReadRepository.FindApplicantByIdIncludeBankAccount(request.ApplicantId);

            if (applicant == null)
                throw new NotFoundException("چنین درخواستگری موجود نیست!");

            if (applicant.UserConfirmation.TotalConfirmation)
            {
                throw new DomainException(Resources.Messages.ExceptionOnUpdateConfirmedApplicant);
            }

            applicant.AddBankInformation(request.ShabaNumber,request.BankCartNumber,request.BankType,request.IsActive);
            _applicantRepository.Update(applicant);
            await _unitOfWork.CommitAsync();

            return new ApplicantCompleteInformationCommandResult() { Message = "عملیات با موفقیت انجام شد." };

        }

    }
}