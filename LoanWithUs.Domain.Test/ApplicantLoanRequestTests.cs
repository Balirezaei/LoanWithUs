using FluentAssertions;
using LoanWithUs.Common;
using LoanWithUs.Common.DefinedType;
using LoanWithUs.Domain.Test.Utility;
using LoanWithUs.Exceptions;
using LoanWithUs.Resources;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.Domain.Test
{
    public class QualifiedApplicantLoanRequestTest
    {
        Applicant Applicant;
        private string reason = "UnitTest";

        public QualifiedApplicantLoanRequestTest()
        {
            Applicant = new ApplicantBuilder().Build();
            Administrator administrator = new AdministratorBuilder().Build();
            Applicant = administrator.ConfirmApplicant(Applicant);

        }
        private IApplicantLoanRequestDomainService GetApplicantLoanRequestDomainService(bool validateFrame, bool notSettelledLoan, bool openRequest)
        {
            var _applicantDomainService = Substitute.For<IApplicantLoanRequestDomainService>();
            _applicantDomainService.ValidateFrameByApplicant(default, default).ReturnsForAnyArgs(validateFrame);
            _applicantDomainService.HasNotSettelledLoan(default).ReturnsForAnyArgs(notSettelledLoan);
            _applicantDomainService.HasOpenRequest(default).ReturnsForAnyArgs(openRequest);
            return _applicantDomainService;
        }
        private ApplicantLoanRequest RequestNewLoan(Amount amount, int installment, IApplicantLoanRequestDomainService _applicantDomainService)
        {
            IDateTimeServiceProvider dateProvider = new DateTimeServiceProvider();
            return Applicant.RequestNewLoan(reason, amount, new LoanLadderInstallmentsCount(installment), _applicantDomainService, dateProvider);
        }
        [Fact]
        public void Applicant_Can_Request_Loan_In_First_Step_With_Sufficient_Supporter_Credit()
        {
            var amount = LoanLadderFrameFactory.StepOne().Amount;

            var _applicantDomainService = GetApplicantLoanRequestDomainService(true, false, false);

            var request = RequestNewLoan(amount, 6, _applicantDomainService);
            Applicant.LoanRequests.Count().Should().Be(1);
            request.LastState.Should().Be(Common.Enum.ApplicantLoanRequestState.ApplicantRequested);
        }


        [Fact]
        public void Applicant_Receive_Exception_Request_Loan_In_First_Step_Invalid_Amount()
        {
            var invalidAmount = LoanLadderFrameFactory.StepOne().Amount + 100;
            var _applicantDomainService = GetApplicantLoanRequestDomainService(true, false, false);

            //Excersice
            Action comparison = () =>
            {
                RequestNewLoan(invalidAmount, 6, _applicantDomainService);
            };

            //Assertion
            comparison.Should().Throw<DomainException>().WithMessage(Messages.ApplicantLoanRequestInvalidAmount);

        }

        /// <summary>
        /// این  تست در حال حاضر امکان اجرا ندارد
        /// مکانیزم های کم شدن اعتبار پشتیبان 
        /// یا رفتن به نردبان های بعدی در حال حاضر وجود ندارد
        /// </summary>
        [Fact]
        public void Applicant_Can_Not_Request_Loan_In_First_Step_With_Insufficient_Supporter_Credit()
        {
            throw new NotImplementedException();
            //var invalidAmount = LoanLadderFrameFactory.StepOne().Amount * 10000;
            //var _applicantDomainService = GetApplicantLoanRequestDomainService(true, false, false);

            ////Excersice
            //Action comparison = () =>
            //{
            //    Applicant.RequestNewLoan(reason, invalidAmount, new LoanLadderInstallmentsCount(6), _applicantDomainService);

            //};

            ////Assertion
            //comparison.Should().Throw<DomainException>().WithMessage(Messages.ApplicantLoanRequestInsufficientSupporterCredit);
        }
        [Fact]
        public void Applicant_With_Open_Request_Is_Not_Permit_To_Request_New_Loan()
        {
            var amount = LoanLadderFrameFactory.StepOne().Amount;

            var _applicantDomainService = GetApplicantLoanRequestDomainService(true, false, true);

            //Excersice
            Action comparison = () =>
            {
                RequestNewLoan(amount, 6, _applicantDomainService);

            };

            //Assertion
            comparison.Should().Throw<DomainException>().WithMessage(Messages.ApplicantLoanRequestWithOpenRequest);

        }

        [Fact]
        public void Applicant_With_Not_Settelled_Loan_Is_Not_Permit_To_Request_New_Loan()
        {
            var amount = LoanLadderFrameFactory.StepOne().Amount;

            var _applicantDomainService = GetApplicantLoanRequestDomainService(true, true, false);

            //Excersice
            Action comparison = () =>
            {
                RequestNewLoan(amount, 6, _applicantDomainService);

            };

            //Assertion
            comparison.Should().Throw<DomainException>().WithMessage(Messages.ApplicantLoanRequestWithOpenLoan);

        }

    }
}