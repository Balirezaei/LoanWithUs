
namespace LoanWithUs.Domain
{
    public interface ILoanLadderFrameBasicInfoBuilder
    {
        ILoanLadderFrameBasicInfoBuilder WithTitle(string title);
        ILoanLadderFrameBasicInfoBuilder WithStep(int step);
        ILoanLadderFrameBasicInfoBuilder WithParentLadder(LoanLadderFrame parentLoanLadderFrame);
        ILoanLadderFrameInstallmentBuilder WithTomanAmount(int amount);
    }

}
