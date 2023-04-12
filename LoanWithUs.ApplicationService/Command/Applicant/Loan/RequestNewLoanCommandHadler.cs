using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common;
using LoanWithUs.Domain.UserAggregate;
using LoanWithUs.Exceptions;
using MediatR;

namespace LoanWithUs.ApplicationService.Command.Applicant.Loan
{
    public class RequestNewLoanCommandHadler : IRequestHandler<RequestNewLoan, RequestNewLoanResult>
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IApplicantReadRepository _applicantReadRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicantDomainService _applicantDomainService;

        public RequestNewLoanCommandHadler(IApplicantRepository applicantRepository, IApplicantReadRepository applicantReadRepository, IUnitOfWork unitOfWork, IApplicantDomainService applicantDomainService)
        {
            _applicantRepository = applicantRepository;
            _applicantReadRepository = applicantReadRepository;
            _unitOfWork = unitOfWork;
            _applicantDomainService = applicantDomainService;
        }

        public async Task<RequestNewLoanResult> Handle(RequestNewLoan request, CancellationToken cancellationToken)
        {
            var applicant = await _applicantReadRepository.FindApplicantByIdIncludeEducationalInformation(request.ApplicantId);
            if (applicant == null)
                throw new NotFoundException("چنین درخواستگری موجود نیست!");

            //applicant.RequestNewLoan();
            throw new NotImplementedException();



        }
    }
}
