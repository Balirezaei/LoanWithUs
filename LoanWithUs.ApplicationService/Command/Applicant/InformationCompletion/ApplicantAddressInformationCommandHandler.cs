using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common;
using LoanWithUs.Domain;
using LoanWithUs.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LoanWithUs.ApplicationService.Command
{
    public class ApplicantAddressInformationCommandHandler : IRequestHandler<ApplicantAddressInformationCommand, ApplicantCompleteInformationCommandResult>
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IApplicantReadRepository _applicantReadRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<City> _cityRepository;
        public ApplicantAddressInformationCommandHandler(IApplicantRepository applicantRepository, IApplicantReadRepository applicantReadRepository, IUnitOfWork unitOfWork, IGenericRepository<City> cityRepository)
        {
            _applicantRepository = applicantRepository;
            _applicantReadRepository = applicantReadRepository;
            _unitOfWork = unitOfWork;
            _cityRepository = cityRepository;
        }

        public async Task<ApplicantCompleteInformationCommandResult> Handle(ApplicantAddressInformationCommand request, CancellationToken cancellationToken)
        {
            var applicant = await _applicantReadRepository.FindApplicantByIdIncludeAddressInformation(request.ApplicantId);

            if (applicant == null)
                throw new NotFoundException("چنین درخواستگری موجود نیست!");

            if (applicant.UserConfirmation.TotalConfirmation)
            {
                throw new DomainException(Resources.Messages.ExceptionOnUpdateConfirmedApplicant);
            }

            var city = await _cityRepository.GetByPredicate(m => m.Id == request.CityId).Include(m => m.Province).FirstOrDefaultAsync();

            var addressInformation = new AddressInformationBuilder()
                .WithHomeInfo(request.PostalCode, request.HomePhone, request.HomePhone)
                .WithCity(city)
                .WithWorkInfo(request.WorkAddress, request.WorkPhone)
                .Build();

            applicant.UpdateAddressInformation(addressInformation);
            _applicantRepository.Update(applicant);
            await _unitOfWork.CommitAsync();

            return new ApplicantCompleteInformationCommandResult() { Message = "عملیات با موفقیت انجام شد." };
        }
    }
}