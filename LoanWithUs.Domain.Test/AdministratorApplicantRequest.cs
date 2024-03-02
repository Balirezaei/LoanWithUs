using FluentAssertions;
using LoanWithUs.Common;
using LoanWithUs.Common.ExtentionMethod;
using LoanWithUs.Domain.Test.Utility;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.Domain.Test
{
    public class AdministratorApplicantRequestTests
    {
        private Supporter supporter;
        private readonly Applicant applicant;
        private ApplicantLoanRequest applicantLoanRequest;
        IDateTimeServiceProvider dateProvider;
        private Administrator administrator;
        private int LoanAmount= 1000000;

        public AdministratorApplicantRequestTests()
        {
            administrator = new AdministratorBuilder().Build();

            supporter = new SupporterBuilder().Build();
            applicant = new ApplicantBuilder()
                .WithSupporter(supporter)
                .Build();
            administrator.ConfirmApplicant(applicant);

            var _applicantDomainService = Substitute.For<IApplicantLoanRequestDomainService>();
            _applicantDomainService.ValidateFrameByApplicant(default, default).ReturnsForAnyArgs(true);
            _applicantDomainService.HasNotSettelledLoan(default).ReturnsForAnyArgs(false);
            _applicantDomainService.HasOpenRequest(default).ReturnsForAnyArgs(false);
            dateProvider = new DateTimeServiceProvider();

            applicantLoanRequest = applicant.RequestNewLoan("Unit Test", "Unit Test", new Common.DefinedType.Amount(1000000, Common.Enum.MoneyType.Toman), new LoanLadderInstallmentsCount(6), _applicantDomainService, dateProvider);
            supporter.ConfirmApplicantLoanRequest(applicantLoanRequest,dateProvider);

        }

        [Fact]
        public void AdminCanConfirmLoanRequest()
        {
            administrator.ConfirmApplicantLoanRequest(applicantLoanRequest,dateProvider);
            applicantLoanRequest.LastState.Should().Be(Common.Enum.ApplicantLoanRequestState.ReadyToPay);
            applicantLoanRequest.Flows.FirstOrDefault(m => m.State == Common.Enum.ApplicantLoanRequestState.ReadyToPay).Should().NotBeNull();
        }


        [Fact]
        public void AdminCanRejectLoanRequest()
        {
            administrator.RejectApplicantLoanRequest(applicantLoanRequest,"Unit Test", dateProvider);

            applicantLoanRequest.LastState.Should().Be(Common.Enum.ApplicantLoanRequestState.AdminRejected);

            applicantLoanRequest.Flows.FirstOrDefault(m => m.State == Common.Enum.ApplicantLoanRequestState.AdminRejected).Should().NotBeNull();
        }

        [Fact]
        public void AfterAdminRejectSupporterCreditShouldBackToPreviousAmount()
        {
            supporter.GetAvailableCredit().Should().Be((StaticDataForBegining.InitCreditForSupporter - LoanAmount).ToToman());

            administrator.RejectApplicantLoanRequest(applicantLoanRequest, "Unit Test", dateProvider);

            supporter.GetAvailableCredit().Should().Be(StaticDataForBegining.InitCreditForSupporter.ToToman());
        }

        [Fact]
        public void After_Admin_Paied_Applicant_Loan_Request_Loan_Is_Create()
        {
            administrator.ConfirmApplicantLoanRequest(applicantLoanRequest, dateProvider);
            var loan=administrator.PaiedApplicantLoanRequest(applicantLoanRequest, new LoanWithUsFile("", "", "", "", FileType.DepositReceipt), StaticDataForBegining.LoanWage, dateProvider);
            loan.Should().NotBeNull();
            loan.LoanInstallments.Count().Should().Be(applicantLoanRequest.InstallmentsCount);
        }

    }
}
