using LoanWithUs.ApplicationService.Contract.Administrator;
using LoanWithUs.Common;
using LoanWithUs.Common.ExtentionMethod;
using LoanWithUs.Domain;
using LoanWithUs.Exceptions;
using MediatR;

namespace LoanWithUs.ApplicationService.Command.Administrator
{
    public class LoanLadderFrameCreateCommandHandler : IRequestHandler<LoanLadderFrameCreateCommand, LoanLadderFrameCreateCommandResult>
    {
        private readonly ILoanLadderFrameRepository _loanLadderFrameRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoanLadderFrameDomainService _domainService;

        public LoanLadderFrameCreateCommandHandler(ILoanLadderFrameRepository loanLadderFrameRepository, IUnitOfWork unitOfWork, ILoanLadderFrameDomainService domainService)
        {
            _loanLadderFrameRepository = loanLadderFrameRepository;
            _unitOfWork = unitOfWork;
            _domainService = domainService;
        }

        public async Task<LoanLadderFrameCreateCommandResult> Handle(LoanLadderFrameCreateCommand request, CancellationToken cancellationToken)
        {
            var parent = await _loanLadderFrameRepository.GetById(request.ParentId);
            if (parent == null)
            {
                throw new DomainException("انتخاب نردبان مرحله قبل الزامیست!");
            }
            var builder = new LoanLadderFrameBuilder(_domainService)
                .WithTitle(request.Title)
                .WithStep(request.Step)
                .WithParentLadder(parent)
                .WithTomanAmount(request.Amount);

            if (request.InstallmentCouts.Any())
            {
                foreach (var item in request.InstallmentCouts)
                {
                    switch (item.Count)
                    {
                        case 6:
                            builder = builder.With6MoInstallment();
                            break;
                        case 12:
                            builder = builder.With12MoInstallment();
                            break;
                        case 18:
                            builder = builder.With18MoInstallment();
                            break;
                        case 24:
                            builder = builder.With24MoInstallment();
                            break;
                        case 36:
                            builder = builder.With36MoInstallment();
                            break;
                        default:
                            break;
                    }
                }
            }
            var loanLoadderFrame = builder.Build();

            await _loanLadderFrameRepository.Add(loanLoadderFrame);
            await _unitOfWork.CommitAsync();


            return new LoanLadderFrameCreateCommandResult
            {
                Id = loanLoadderFrame.Id,
            };
        }
    }


}
