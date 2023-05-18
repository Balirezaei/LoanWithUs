using AutoMapper;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common;
using LoanWithUs.Domain;
using MediatR;

namespace LoanWithUs.ApplicationService.Command.Applicant.Loan
{
    public class ApplicantInstallmentPaymentCommandHadler : IRequestHandler<ApplicantInstallmentPaymentCommand, ApplicantPaymentResult>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IUnitOfWork _unitOfWork;
        private IDateTimeServiceProvider _dateProvider;
        private IApplicantDomainService _applicantDomainService;

        public ApplicantInstallmentPaymentCommandHadler(ILoanRepository loanRepository, IUnitOfWork unitOfWork, IDateTimeServiceProvider dateProvider, IApplicantDomainService applicantDomainService)
        {
            _loanRepository = loanRepository;
            _unitOfWork = unitOfWork;
            _dateProvider = dateProvider;
            _applicantDomainService = applicantDomainService;
        }

        public async Task<ApplicantPaymentResult> Handle(ApplicantInstallmentPaymentCommand request, CancellationToken cancellationToken)
        {
            var activeLoan =await _loanRepository.GetActiveLoan(request.ApplicantId);
            activeLoan.PaidInstallmentByApplicant(request.UniqueIdentity, _applicantDomainService, _dateProvider);
            await _unitOfWork.CommitAsync();
            return new ApplicantPaymentResult { };
        }
    }
}
