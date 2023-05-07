using LoanWithUs.ApplicationService.Contract.Administrator;
using LoanWithUs.Common;
using LoanWithUs.Common.ExtentionMethod;
using LoanWithUs.Domain;
using LoanWithUs.Encryption;
using MediatR;

namespace LoanWithUs.ApplicationService.Command.Administrator
{
    public class AdminRegisterSupporterCommandHandler : IRequestHandler<AdminRegisterSupporterCommand, AdminRegisterSupporterCommandResult>
    {
        private readonly ISupporterRepository _supporterRepository;
        private readonly IAdministratorRepository _administratorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISupporterDomainService _supporterDomainService;
        private readonly IDateTimeServiceProvider _dateProvider;
        public AdminRegisterSupporterCommandHandler(ISupporterRepository supporterRepository, IUnitOfWork unitOfWork, IAdministratorRepository administratorRepository, ISupporterDomainService supporterDomainService, IDateTimeServiceProvider dateProvider)
        {
            _supporterRepository = supporterRepository;
            _unitOfWork = unitOfWork;
            _administratorRepository = administratorRepository;
            _supporterDomainService = supporterDomainService;
            _dateProvider = dateProvider;
        }

        public async Task<AdminRegisterSupporterCommandResult> Handle(AdminRegisterSupporterCommand request, CancellationToken cancellationToken)
        {
            var admin = await _administratorRepository.FindAdministratorById(request.AdminId);
            if (admin == null)
            {
                throw new Exception("Current User Not Found");
            }

            var supporter = admin.DefineNewSupporter(request.NationalCode, request.MobileNumber, StaticDataForBegining.InitCreditForSupporter.ToToamn(), _supporterDomainService,_dateProvider);

            _supporterRepository.Add(supporter);

            await _unitOfWork.CommitAsync();
            return new AdminRegisterSupporterCommandResult(supporter.Id);
        }

    }
}
