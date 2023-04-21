using FluentAssertions;
using LoanWithUs.ApplicationService.Contract.Administrator;
using LoanWithUs.ApplicationService.Contract.Applicant;
using LoanWithUs.Common.ExtentionMethod;
using LoanWithUs.IntegrationTest.Utility.WebFactory;
using LoanWithUs.Resources;
using LoanWithUs.ViewModel;
using Newtonsoft.Json;
using System.Net;


namespace LoanWithUs.IntegrationTest.InSqlTest.ApiAutomation
{
    public class QualifiedApplicantLoanRequestTests : IClassFixture<ToSqlTestingByApplicant>
    {
        private readonly ToSqlTestingByApplicant _toTesting;

        public QualifiedApplicantLoanRequestTests(ToSqlTestingByApplicant toSqlTesting)
        {
            _toTesting = toSqlTesting;
        }


        [Fact]
        public async Task Request_New_Loan_With_Valid_Info()
        {
            //Setup
            var vm = new ApplicantRequestLoanVm()
            {
                Amount = 500000,
                LoanLadderInstallmentsCount = 6,
                Reason = "Integration Test"
            };

            await _toTesting.ConfirmApplicant();

            //Exersice
            var response = await _toTesting.CallPostApi<ApplicantRequestLoanVm>(vm, "/LoanRequest/RequestNewLoan");

            //Verification
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var responseText = await response.Content.ReadAsStringAsync();
            var loanRequest = JsonConvert.DeserializeObject<ApplicantRequestLoanResult>(responseText);
            loanRequest.TrackingNumber.Should().NotBeNullOrEmpty();

            //TearDown

            await _toTesting.SendAsync(new DeactiveLoanRequest() { ApplicantId = _toTesting.CurrentUser.UserId });

        }


        [Fact]
        public async Task Request_New_Loan_With_Invalid_Installment_Should_Receive_Exception()
        {
            //Setup
            var vm = new ApplicantRequestLoanVm()
            {
                Amount = 500000,
                LoanLadderInstallmentsCount = 7,
                Reason = "Integration Test"
            };
            await _toTesting.ConfirmApplicant();

            //Exersice
            var response = await _toTesting.CallPostApi<ApplicantRequestLoanVm>(vm, "/LoanRequest/RequestNewLoan");

            //Verification
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            var responseText = await response.Content.ReadAsStringAsync();

            //var errorResult = JsonConvert.DeserializeObject<dynamic>(responseText);

            responseText.Should().Contain(Messages.ApplicantLoanRequestWithInvalidInstallment);

        }


        [Fact]
        public async Task With_Valid_Supporter_On_First_Ladder_Get_Corresponding_Info_Of_Loan()
        {
            await _toTesting.ConfirmApplicant();


            var response = await _toTesting.CallGetApi("/LoanRequest/GetLatestLoanRequestAvailability");
            var responseText = await response.Content.ReadAsStringAsync();
            var applicantLoanRequestAvailability = JsonConvert.DeserializeObject<ApplicantLoanRequestAvailability>(responseText);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            applicantLoanRequestAvailability.CanRequestALoan.Should().Be(true);
            applicantLoanRequestAvailability.ApplicantAvailabileLoanDetail.MaxLoanAmount.Should().Be(StaticDate.FirstStepLadderAmount);
        }

        //[Fact]
        //public async Task With_Insufficient_Supporter_Get_Corresponding_Info_Of_Loan()
        //{

        //    throw new NotImplementedException();
        //}


        [Fact]
        public async Task With_Active_Loan_Request_Get_Corresponding_Info()
        {
            await _toTesting.ConfirmApplicant();

            //Fixture
            await _toTesting.WithMockLoanRequestByApplicant();

            //Exersice
            var response = await _toTesting.CallGetApi("/LoanRequest/GetLatestLoanRequestAvailability");

            var responseText = await response.Content.ReadAsStringAsync();
            var applicantLoanRequestAvailability = JsonConvert.DeserializeObject<ApplicantLoanRequestAvailability>(responseText);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            applicantLoanRequestAvailability.CanRequestALoan.Should().Be(false);
            applicantLoanRequestAvailability.Description = Messages.ApplicantLoanRequestWithOpenRequest;

            //TearDown

            await _toTesting.SendAsync(new DeactiveLoanRequest() { ApplicantId = _toTesting.CurrentUser.UserId });


        }

    }
}
