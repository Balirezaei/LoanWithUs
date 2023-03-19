using LoanWithUs.ApplicationService.Contract.Administrator;
using LoanWithUs.Common;
using LoanWithUs.Domain;
using MediatR;

namespace LoanWithUs.ApplicationService.Command.Administrator
{
    public class LoanLadderFrameAppendInstallmentCommandHandler : IRequestHandler<LoanLadderFrameAppendInstallmentCommand>
    {
        private readonly ILoanLadderFrameRepository _loanLadderFrameRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoanLadderFrameDomainService _domainService;

        public LoanLadderFrameAppendInstallmentCommandHandler(ILoanLadderFrameRepository loanLadderFrameRepository, IUnitOfWork unitOfWork, ILoanLadderFrameDomainService domainService)
        {
            _loanLadderFrameRepository = loanLadderFrameRepository;
            _unitOfWork = unitOfWork;
            _domainService = domainService;
        }

        public async Task<Unit> Handle(LoanLadderFrameAppendInstallmentCommand request, CancellationToken cancellationToken)
        {
            LoanLadderFrame loanLadderFrame = await _loanLadderFrameRepository.GetById(request.LoanLadderFrameId);

            loanLadderFrame.InsertInstallment(request.InstallmentCount);
            _loanLadderFrameRepository.Update(loanLadderFrame);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }

}