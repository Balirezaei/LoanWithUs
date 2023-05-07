using AutoMapper;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common;
using LoanWithUs.Domain;
using MediatR;
namespace LoanWithUs.ApplicationService.Command.Supporter
{
    public class SupporterConfirmLoanRequestCommandHandler : IRequestHandler<SupporterConfirmLoanRequestCommand, SupporterConfirmLoanRequestResult>
    {
        private readonly ISupporterRepository _supporterRepository;
        private readonly IApplicantLoanRequestRepository _applicantLoanRequestRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeServiceProvider _dateProvider;

        public SupporterConfirmLoanRequestCommandHandler(ISupporterRepository supporterRepository, IApplicantLoanRequestRepository applicantLoanRequestRepository, IUnitOfWork unitOfWork, IDateTimeServiceProvider dateProvider)
        {
            _supporterRepository = supporterRepository;
            _applicantLoanRequestRepository = applicantLoanRequestRepository;
            _unitOfWork = unitOfWork;
            _dateProvider = dateProvider;
        }

        public async Task<SupporterConfirmLoanRequestResult> Handle(SupporterConfirmLoanRequestCommand request, CancellationToken cancellationToken)
        {
            var supporter = await _supporterRepository.GetSupporterByIdWithCreditInclude(request.SupporterId);
            var applicantLoanRequest =await _applicantLoanRequestRepository.FindApplicantLoanRequest(request.LoanRequestId);
            supporter.ConfirmApplicantLoanRequest(applicantLoanRequest, _dateProvider);
            await _unitOfWork.CommitAsync();
            return new SupporterConfirmLoanRequestResult();
        }
    }

}
