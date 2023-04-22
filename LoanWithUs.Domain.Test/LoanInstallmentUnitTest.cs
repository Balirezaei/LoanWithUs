using FluentAssertions;
using LoanWithUs.Common.DefinedType;
using LoanWithUs.Domain.Test.Utility;
using LoanWithUs.Domain;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanWithUs.Common;

namespace LoanWithUs.Domain.Test
{
    public class LoanInstallmentUnitTest
    {

        private Applicant applicant;
        IDateTimeServiceProvider dateProvider;
        public LoanInstallmentUnitTest()
        {

            dateProvider = new DateTimeServiceProvider();
            applicant = new ApplicantBuilder().Build();
        }

        [Theory]
        [InlineData(1000000, 5, 200000)]
        [InlineData(2000000, 5, 400000)]
        [InlineData(4000000, 10, 400000)]
        public void TheInstalmentShouldWorkProperlyWithRoundPricingAndCount(int amount, int instalmentCount, int installmentExpect)
        {
            var loan = new Loan(new Amount(amount, Common.Enum.MoneyType.Toman), applicant, instalmentCount, dateProvider);
            loan.LoanInstallments.Should().HaveCount(c => c == instalmentCount);
            loan.LoanInstallments.Select(c => c.Amount).First().Should().Be(installmentExpect);
        }

        [Theory]
        [InlineData(1000000, 6, 166666, 166670)]
        [InlineData(1000000, 12, 83333, 83337)]
        [InlineData(2000000, 6, 333333, 333335)]
        [InlineData(2000000, 12, 166666, 166674)]
        [InlineData(4000000, 12, 333333, 333337)]
        [InlineData(4000000, 24, 166666, 166682)]
        public void TheInstalmentShouldWorkProperlyWithNOTRoundPricingAndCount(int amount, int instalmentCount, int installmentExpect, int lastInstallmentExpect)
        {
            var loan = new Loan(new Amount(amount, Common.Enum.MoneyType.Toman), applicant, instalmentCount, dateProvider);

            loan.LoanInstallments.Should().HaveCount(c => c == instalmentCount);
            loan.LoanInstallments.Select(c => c.Amount).First().Should().Be(installmentExpect);
            loan.LoanInstallments.Select(c => c.Amount).Last().Should().Be(lastInstallmentExpect);
        }

    }
}
