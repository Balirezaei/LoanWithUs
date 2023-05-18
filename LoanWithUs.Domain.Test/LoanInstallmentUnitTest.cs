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

        public LoanInstallmentUnitTest()
        {

            dateProvider = new DateTimeServiceProvider();
            var _applicantDomainService = Substitute.For<IApplicantDomainService>();
            _applicantDomainService.IsMobileReservedWithAllUserType(default, default).ReturnsForAnyArgs(false);
            var stepOne = LoanLadderFrameFactory.StepForth();
            _applicantDomainService.InitLoaderForApplicant().Returns(stepOne);
            applicant = new ApplicantBuilder().WithApplicantDomainService(_applicantDomainService).Build();


            dateProvider = new DateTimeServiceProvider();
            //supporter = new SupporterBuilder().Build();
        }
        private IApplicantLoanRequestDomainService GetApplicantLoanRequestDomainService(bool validateFrame, bool notSettelledLoan, bool openRequest)
        {
            var _applicantDomainService = Substitute.For<IApplicantLoanRequestDomainService>();
            _applicantDomainService.ValidateFrameByApplicant(default, default).ReturnsForAnyArgs(validateFrame);
            _applicantDomainService.HasNotSettelledLoan(default).ReturnsForAnyArgs(notSettelledLoan);
            _applicantDomainService.HasOpenRequest(default).ReturnsForAnyArgs(openRequest);
            return _applicantDomainService;
        }

        private Loan CreateLoan(int amount, int instalmentCount)
        {
            var supporter = new SupporterBuilder().Build();

            var admin = new AdministratorBuilder().Build();
            admin.ConfirmApplicant(applicant);
            var loanRequest = applicant.RequestNewLoan("", "", new Amount(amount, Common.Enum.MoneyType.Toman), new LoanLadderInstallmentsCount(instalmentCount), GetApplicantLoanRequestDomainService(true, false, false), dateProvider);
            supporter.ConfirmApplicantLoanRequest(loanRequest, dateProvider);
            admin.ConfirmApplicantLoanRequest(loanRequest, dateProvider);
            return admin.PaiedApplicantLoanRequest(loanRequest, new LoanWithUsFile("", "", "", "", FileType.DepositReceipt), dateProvider);

        }
        [Theory]
        [InlineData(1000000, 5, 200000, 15000)]
        [InlineData(2000000, 5, 400000, 30000)]
        [InlineData(4000000, 10, 400000, 60000)]
        public void TheInstalmentShouldWorkProperlyWithRoundPricingAndCount(int amount, int instalmentCount, int installmentExpect, int amountWithWage)
        {
            //_administrator.
            var loan = CreateLoan(amount, instalmentCount);
            loan.LoanInstallments.Should().HaveCount(c => c == instalmentCount);
            loan.LoanInstallments.Select(c => c.Amount).First().Should().Be(installmentExpect);
            loan.LoanInstallments.Select(c => c.Amount).Last().Should().Be(installmentExpect + amountWithWage);
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
            loan.LoanInstallments.Select(c => c.Amount).ToArray()[0].Should().Be(installmentExpect);
            loan.LoanInstallments.Select(c => c.Amount).Last().Should().Be(lastInstallmentExpect + amountWithWage);
        }

    }
}
