namespace LoanWithUs.Domain 
{ 
    public interface ILoanLadderFrameInstallmentBuilder
    {

        ILoanLadderFrameInstallmentBuilder With6MoInstallment();
        ILoanLadderFrameInstallmentBuilder With36MoInstallment();
        ILoanLadderFrameInstallmentBuilder With24MoInstallment();
        ILoanLadderFrameInstallmentBuilder With18MoInstallment();
        ILoanLadderFrameInstallmentBuilder With12MoInstallment();
        LoanLadderFrame Build(int id = 0);
    }

}
