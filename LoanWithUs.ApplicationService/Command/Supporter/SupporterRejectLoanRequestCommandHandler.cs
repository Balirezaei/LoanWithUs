using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common;
using LoanWithUs.Domain;
using MediatR;
namespace LoanWithUs.ApplicationService.Command.Supporter
{
    public class SupporterRejectLoanRequestCommandHandler : IRequestHandler<SupporterRejectLoanRequestCommand, SupporterRejectLoanRequestResult>
    {
        private readonly ISupporterRepository _supporterRepository;
        private readonly IApplicantLoanRequestRepository _applicantLoanRequestRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeServiceProvider _dateProvider;

        public SupporterRejectLoanRequestCommandHandler(ISupporterRepository supporterRepository, IApplicantLoanRequestRepository applicantLoanRequestRepository, IUnitOfWork unitOfWork, IDateTimeServiceProvider dateProvider)
        {
            _supporterRepository = supporterRepository;
            _applicantLoanRequestRepository = applicantLoanRequestRepository;
            _unitOfWork = unitOfWork;
            _dateProvider = dateProvider;
        }

        public async Task<SupporterRejectLoanRequestResult> Handle(SupporterRejectLoanRequestCommand request, CancellationToken cancellationToken)
        {
            var supporter = await _supporterRepository.GetSupporterById(request.SupporterId);
            var applicantLoanRequest = await _applicantLoanRequestRepository.FindApplicantLoanRequest(request.LoanRequestId);
            supporter.RejectApplicantLoanRequest(applicantLoanRequest, _dateProvider);
            await _unitOfWork.CommitAsync();
            return new SupporterRejectLoanRequestResult();
        }
    }

}
