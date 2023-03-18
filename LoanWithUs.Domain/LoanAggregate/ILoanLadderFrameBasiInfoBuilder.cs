using LoanWithUs.Domain.LoanAggregate;

namespace LoanWithUs.Domain
{
    public interface ILoanLadderFrameBasiInfoBuilder
    {
        ILoanLadderFrameBasiInfoBuilder WithTitle(string title);
        ILoanLadderFrameBasiInfoBuilder WithStep(int step);
        ILoanLadderFrameBasiInfoBuilder WithParentLadder(LoanLadderFrame parentLoanLadderFrame);
        ILoanLadderFrameInstallmentBuilder WithTomanAmount(int amount);
    }

}
