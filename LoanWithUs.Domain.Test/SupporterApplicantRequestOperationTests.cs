using FluentAssertions;
using LoanWithUs.Common;
using LoanWithUs.Domain.Test.Utility;
using LoanWithUs.Exceptions;
using LoanWithUs.Resources;
using NSubstitute;

namespace LoanWithUs.Domain.Test
{
    public class SupporterApplicantRequestOperationTests
    {
        private Supporter supporter;
        private readonly Applicant applicant;
        private ApplicantLoanRequest ApplicantLoanRequest;
        IDateTimeServiceProvider dateProvider;

        public SupporterApplicantRequestOperationTests()
        {
            var admin = new AdministratorBuilder().Build();

            supporter = new SupporterBuilder().Build();
            applicant = new ApplicantBuilder()
                .WithSupporter(supporter)
                .Build();
            admin.ConfirmApplicant(applicant);

            var _applicantDomainService = Substitute.For<IApplicantLoanRequestDomainService>();
            _applicantDomainService.ValidateFrameByApplicant(default, default).ReturnsForAnyArgs(true);
            _applicantDomainService.HasNotSettelledLoan(default).ReturnsForAnyArgs(false);
            _applicantDomainService.HasOpenRequest(default).ReturnsForAnyArgs(false);
            dateProvider = new DateTimeServiceProvider();

            ApplicantLoanRequest = applicant.RequestNewLoan("Unit Test", "Unit Test", new Common.DefinedType.Amount(1000000, Common.Enum.MoneyType.Toman), new LoanLadderInstallmentsCount(6), _applicantDomainService, dateProvider);
        }



        [Fact]
        public async Task SupporterWithSufficiantCreditCanConfirmRequest()
        {
            var initCredit = supporter.GetAvailableCredit();
            var expectedCredit = initCredit - ApplicantLoanRequest.Amount;

            supporter.ConfirmApplicantLoanRequest(ApplicantLoanRequest, dateProvider);

            ApplicantLoanRequest.LastState.Should().Be(Common.Enum.ApplicantLoanRequestState.SupporterAccepted);

            supporter.GetAvailableCredit().Should().Be(expectedCredit);
        }

        [Fact]
        public async Task SupporterWithInSufficiantCreditCanNotConfirmRequest()
        {
            supporter = new SupporterBuilder().WithInitAmount(0).Build();
          
            Action comparison = () =>
            {
                supporter.ConfirmApplicantLoanRequest(ApplicantLoanRequest, dateProvider);
            };

            //Assertion
            comparison.Should().Throw<DomainException>().WithMessage(Messages.SupporterInsufficientAmountToConfirmRequest);


        }

        [Fact]
        public async Task SupporterCanNotRejectRequest()
        {
            supporter.RejectApplicantLoanRequest(ApplicantLoanRequest, dateProvider);
            ApplicantLoanRequest.LastState.Should().Be(Common.Enum.ApplicantLoanRequestState.SupporterRejected);


        }

    }
}