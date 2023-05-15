using FluentAssertions;
using LoanWithUs.Common;
using LoanWithUs.Domain.Test.Utility;
using LoanWithUs.Exceptions;
using LoanWithUs.Resources;
using NSubstitute;

namespace LoanWithUs.Domain.Test
{
    public class NotQulifiedApplicantLoanRequestTest
    {
        Applicant Applicant;

        public NotQulifiedApplicantLoanRequestTest()
        {
            Applicant = new ApplicantBuilder().Build();
        }

        [Fact]
        public void Applicant_On_Request_Receive_Exception()
        {
            var dService = Substitute.For<IApplicantLoanRequestDomainService>();
           var dateProvider = new DateTimeServiceProvider();
            //Excersice
            Action comparison = () =>
            {
                Applicant.RequestNewLoan("","", LoanLadderFrameFactory.StepOne().Amount, new LoanLadderInstallmentsCount(6), dService, dateProvider);
            };

            //Assertion
            comparison.Should().Throw<DomainException>().WithMessage(Messages.ApplicantLoanRequestNotConfirmedInfo);
        }
    }
}
