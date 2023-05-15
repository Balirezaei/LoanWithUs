using AutoMapper;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common;
using LoanWithUs.Common.ExtentionMethod;
using LoanWithUs.Domain;
using MediatR;

namespace LoanWithUs.ApplicationService.Query.Applicant
{
    public class GetActiveApplicantLoanQueryHandler : IRequestHandler<GetActiveApplicantLoan, ActiveApplicantLoan>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IMapper _mapper;
        private IDateTimeServiceProvider _dateProvider;

        public GetActiveApplicantLoanQueryHandler(ILoanRepository loanRepository, IMapper mapper, IDateTimeServiceProvider dateProvider)
        {
            _loanRepository = loanRepository;
            _mapper = mapper;
            this._dateProvider = dateProvider;
        }

        public async Task<ActiveApplicantLoan> Handle(GetActiveApplicantLoan request, CancellationToken cancellationToken)
        {
            var activeLoan = await _loanRepository.GetActiveLoan(request.ApplicantId);

            return new ActiveApplicantLoan
            {
                Amount = activeLoan.Amount.amount.ToStringSplit3Digit(),
                ReceiptFile = _mapper.Map<FileDto>(activeLoan.ReciptFile),
                StartDate = activeLoan.StartDate.M2S(),
                SupporterFullName = activeLoan.LoanRequiredDocuments.FirstOrDefault(m => m.Type == Common.LoanRequiredDocumentType.Supporter).Description,
                Installments = activeLoan.LoanInstallments.Select(m => new ApplicantLoanRequestInstallmentDto
                {
                    Amount = m.Amount.ToStringSplit3Digit(),
                    EndDateForPay = m.EndDate.M2S(),
                    StartDateForPay = m.StartDate.M2S(),
                    IsPaid = m.PaiedDate != null,
                    Step = m.Step,
                    PaidDate = m.PaiedDate != null ? m.PaiedDate.Value.M2S() : "",
                    ReadyToPay = m.PaiedDate == null && _dateProvider.GetDate() > m.StartDate
                }).ToList()
            };
        }
    }
}