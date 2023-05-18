using LoanWithUs.Common.DefinedType;

namespace LoanWithUs.Domain
{
    public class LoanLadderFrameBuilder : ILoanLadderFrameBasicInfoBuilder, ILoanLadderFrameInstallmentBuilder
    {
        private List<LoanLadderInstallmentsCount> _loanLadderInstallments;
        private string _title;
        private int _step;
        private Amount _amount = new Amount(0, Common.Enum.MoneyType.Toman);
        private LoanLadderFrame _parentLoanLadderFrame;
        private ILoanLadderFrameDomainService _domainService;

        public LoanLadderFrameBuilder(ILoanLadderFrameDomainService domainService)
        {
            _loanLadderInstallments = new List<LoanLadderInstallmentsCount>();
            _domainService = domainService;
             _step = 1;
        }

        //public ILoanLadderFrameBasiInfoBuilder WithDomainService(ILoanLadderFrameDomainService domainService)
        //{
        //    this._domainService = domainService;
        //    return this;
        //}

        public ILoanLadderFrameBasicInfoBuilder WithTitle(string title)
        {
            _title = title;
            return this;
        }
        public ILoanLadderFrameBasicInfoBuilder WithParentLadder(LoanLadderFrame parentLoanLadderFrame)
        {
            _parentLoanLadderFrame = parentLoanLadderFrame;
            return this;
        }
        public ILoanLadderFrameBasicInfoBuilder WithStep(int step)
        {
            _step = step;
            return this;
        }

        public ILoanLadderFrameInstallmentBuilder WithTomanAmount(int amount)
        {
            _amount = new Amount(amount, Common.Enum.MoneyType.Toman);
            return this;
        }
        public LoanLadderFrame Build(int id = 0)
        {
            return new LoanLadderFrame(id, _title, _step, _amount, _parentLoanLadderFrame, _loanLadderInstallments, _domainService);
        }

        public ILoanLadderFrameInstallmentBuilder With6MoInstallment()
        {
            if (!_loanLadderInstallments.Any(m => m.Count == 6))
            {
                _loanLadderInstallments.Add(new LoanLadderInstallmentsCount(6));
            }
            return this;
        }

        public ILoanLadderFrameInstallmentBuilder With12MoInstallment()
        {
            if (!_loanLadderInstallments.Any(m => m.Count == 12))
            {
                _loanLadderInstallments.Add(new LoanLadderInstallmentsCount(12));
            }
            return this;
        }

        public ILoanLadderFrameInstallmentBuilder With18MoInstallment()
        {
            if (!_loanLadderInstallments.Any(m => m.Count == 18))
            {
                _loanLadderInstallments.Add(new LoanLadderInstallmentsCount(18));
            }
            return this;
        }

        public ILoanLadderFrameInstallmentBuilder With24MoInstallment()
        {
            if (!_loanLadderInstallments.Any(m => m.Count == 24))
            {
                _loanLadderInstallments.Add(new LoanLadderInstallmentsCount(24));
            }
            return this;
        }

        public ILoanLadderFrameInstallmentBuilder With36MoInstallment()
        {
            if (!_loanLadderInstallments.Any(m => m.Count == 36))
            {
                _loanLadderInstallments.Add(new LoanLadderInstallmentsCount(36));
            }
            return this;
        }

        public ILoanLadderFrameInstallmentBuilder WithCustomeInstallment(int installment)
        {
            if (!_loanLadderInstallments.Any(m => m.Count == installment))
            {
                _loanLadderInstallments.Add(new LoanLadderInstallmentsCount(installment));
            }
            return this;
        }
    }

}
