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
        private ApplicantLoanRequest applicantLoanRequest;
        IApplicantLoanRequestDomainService domainService;

        public LoanInstallmentUnitTest()
        {

            dateProvider = new DateTimeServiceProvider();
            applicant = new ApplicantBuilder().Build();
            domainService = Substitute.For<IApplicantLoanRequestDomainService>();
            dateProvider = new DateTimeServiceProvider();
            //supporter = new SupporterBuilder().Build();
        }

        private Loan CreateLoan(int amount,int instalmentCount)
        {
            var loanRequest = applicant.RequestNewLoan("", "", new Amount(amount, Common.Enum.MoneyType.Toman), new LoanLadderInstallmentsCount(instalmentCount), domainService, dateProvider);
            return new Loan(loanRequest, null, dateProvider);

        }
        [Theory]
        [InlineData(1000000, 5, 200000, 15000)]
        [InlineData(2000000, 5, 400000, 30000)]
        [InlineData(4000000, 10, 400000, 60000)]
        public void TheInstalmentShouldWorkProperlyWithRoundPricingAndCount(int amount, int instalmentCount, int installmentExpect, int amountWithWage)
        {
            //_administrator.
            var loan=CreateLoan(amount, instalmentCount);
            loan.LoanInstallments.Should().HaveCount(c => c == instalmentCount);
            loan.LoanInstallments.Select(c => c.Amount).Last().Should().Be(installmentExpect);
            loan.LoanInstallments.Select(c => c.Amount).First().Should().Be(installmentExpect + amountWithWage);
        }

        [Theory]
        [InlineData(1000000, 6, 166666, 166670, 15000)]
        [InlineData(1000000, 12, 83333, 83337, 15000)]
        [InlineData(2000000, 6, 333333, 333335, 30000)]
        [InlineData(2000000, 12, 166666, 166674, 30000)]
        [InlineData(4000000, 12, 333333, 333337, 60000)]
        [InlineData(4000000, 24, 166666, 166682, 60000)]
        public void TheInstalmentShouldWorkProperlyWithNOTRoundPricingAndCount(int amount, int instalmentCount, int installmentExpect, int lastInstallmentExpect, int amountWithWage)
        {
            var loan = CreateLoan(amount, instalmentCount);
            loan.LoanInstallments.Should().HaveCount(c => c == instalmentCount);
            loan.LoanInstallments.Select(c => c.Amount).ToArray()[0].Should().Be(installmentExpect + amountWithWage);
            loan.LoanInstallments.Select(c => c.Amount).ToArray()[1].Should().Be(installmentExpect);
            loan.LoanInstallments.Select(c => c.Amount).Last().Should().Be(lastInstallmentExpect);
        }

    }
}
