using FluentAssertions;
using LoanWithUs.IntegrationTest.Utility.WebFactory;
using LoanWithUs.Resources;
using LoanWithUs.ViewModel;
using System.Net;

namespace LoanWithUs.IntegrationTest.InSqlTest.ApiAutomation
{
    public class NotQualifiedApplicantTests : IClassFixture<ToSqlTestingByApplicant>
    {
        private readonly ToSqlTestingByApplicant _toTesting;

        public NotQualifiedApplicantTests(ToSqlTestingByApplicant toSqlTesting)
        {
            _toTesting = toSqlTesting;
        }

        [Fact]
        public async Task NotQualifiedApplicant_Request_New_Loan_With_Valid_Info()
        {
            //Setup
            var vm = new ApplicantRequestLoanVm()
            {
                Amount = 500000,
                LoanLadderInstallmentsCount = 6,
                Reason = "Integration Test"
            };

            //Exersice
            var response = await _toTesting.CallPostApi<ApplicantRequestLoanVm>(vm, "/LoanRequest/RequestNewLoan");

            //Verification
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            var responseText = await response.Content.ReadAsStringAsync();
            //var loanRequest = JsonConvert.DeserializeObject<ApplicantRequestLoanResult>(responseText);
            responseText.Should().Contain(Messages.ApplicantLoanRequestNotConfirmedInfo);

        }


    }
}
