using NSubstitute;

namespace LoanWithUs.Domain.Test.Utility
{
    public class LoanLadderFrameFactory
    {
        public static LoanLadderFrame StepOne()
        {

            var loanLadderApplicantDomainService = Substitute.For<ILoanLadderFrameDomainService>();
            var stepOne = new LoanLadderFrameBuilder(loanLadderApplicantDomainService)
                       .WithTitle("نردبان اول")
                       .WithStep(1)
                       .WithTomanAmount(1000000)
                       .With6MoInstallment()
                       .Build(1);
            return stepOne;
        }

        public static LoanLadderFrame StepForth()
        {

            var loanLadderApplicantDomainService = Substitute.For<ILoanLadderFrameDomainService>();
            var stepOne = new LoanLadderFrameBuilder(loanLadderApplicantDomainService)
                       .WithTitle("نردبان اول")
                       .WithStep(1)
                       .WithTomanAmount(16000000)
                       .With6MoInstallment()
                       .WithCustomeInstallment(5)
                       .WithCustomeInstallment(10)
                       .WithCustomeInstallment(12)
                       .WithCustomeInstallment(24)

                       .Build(1);
            return stepOne;
        }
    }
}
