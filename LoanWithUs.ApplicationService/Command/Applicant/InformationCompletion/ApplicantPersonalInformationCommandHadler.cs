using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common;
using LoanWithUs.Domain;
using LoanWithUs.Exceptions;
using MediatR;

namespace LoanWithUs.ApplicationService.Command
{
    public class ApplicantPersonalInformationCommandHadler : IRequestHandler<ApplicantPersonalInformationCommand, ApplicantCompleteInformationCommandResult>
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IApplicantReadRepository _applicantReadRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ApplicantPersonalInformationCommandHadler(IApplicantRepository applicantRepository, IUnitOfWork unitOfWork, IApplicantReadRepository applicantReadRepository)
        {
            _applicantRepository = applicantRepository;
            _unitOfWork = unitOfWork;
            _applicantReadRepository = applicantReadRepository;
        }

        public async Task<ApplicantCompleteInformationCommandResult> Handle(ApplicantPersonalInformationCommand request, CancellationToken cancellationToken)
        {
            var applicant = await _applicantReadRepository.FindApplicantByIdIncludePersonalInformationAndConfirmation(request.ApplicantId);

            if (applicant == null)
                throw new NotFoundException("چنین درخواستگری موجود نیست!");

            if (applicant.UserConfirmation.TotalConfirmation)
            {
                throw new DomainException(Resources.Messages.ExceptionOnUpdateConfirmedApplicant);
            }

            var newPersonalInfo = new PersonalInformationBuilder()
                  .WithNameAndGender(request.FirstName, request.LastName, request.IsMale)
                  .WithParentName(request.MotherFullName, request.FatherFullName)
                  .WithMarriageInfo(request.IsMarried, request.ChildrenCount)
                  .WithJobInfo(request.Job, request.MinimumIncome)
                  .WithBirthDate(request.BirthDate)
                  .WithIdentityNumber(request.IdentityNumber)
                  .Build();

            applicant.UpdatePersonalInformation(newPersonalInfo);
            _applicantRepository.Update(applicant);
            await _unitOfWork.CommitAsync();

            return new ApplicantCompleteInformationCommandResult() { Message = "عملیات با موفقیت انجام شد." };
        }
    }

}