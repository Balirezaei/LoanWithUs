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
            var activeLoan = await _loanRepository.GetActiveLoanWithDependency(request.ApplicantId);
            var result= _mapper.Map<ActiveApplicantLoan>(activeLoan);
            //result.Installments.Where(m =>  m.PaiedDate == null && m.EndDateForPay < _dateProvider.GetDate())
            //          m.PenaltyDay > 0).Select(m =>
            //{
            //    m.PenaltyAmont = (activeLoan.DailyPenalty * m.PenaltyDay).ToStringSplit3Digit();
            //    return m;
            //});

            return result;
        }
    }
}