using FluentAssertions;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.IntegrationTest.Utility.WebFactory;
using LoanWithUs.ViewModel;
using Newtonsoft.Json;
using System.Net;

namespace LoanWithUs.IntegrationTest.InSqlTest.ApiAutomation
{
    public class SupporterApplicantLoanRequestOperationTests : IClassFixture<ToSqlTestingBySupporterRole>
    {
        private readonly ToSqlTestingBySupporterRole _toTesting;

        public SupporterApplicantLoanRequestOperationTests(ToSqlTestingBySupporterRole toTesting)
        {
            _toTesting = toTesting;
            _toTesting.WithMockLoanRequestByApplicant().Wait();
        }

        [Fact]
        public async Task SupporterShouldReceiveLoanRequests()
        {
            var url = "/SupporterApplicantRequest/GetOpenRequests";

            var vm = new ApplicantOpenRequestGridVm() { PageSize = 10, PageNumber = 1 };

            var response = await _toTesting.CallGetApi<ApplicantOpenRequestGridVm>(vm, url);

            //Verification
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var responseText = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PagedListResult<ApplicantRequestGrid>>(responseText);
            result.List.Count.Should().Be(1);

        }

        [Fact]
        public async Task SupporterCanConfirmLoanRequest()
        {
            var url = "/SupporterApplicantRequest/ConfirmRequest";
            var response = await _toTesting.CallPostApi<SupporterLoanRequestActionViewModel>(new SupporterLoanRequestActionViewModel { RequestId = 1 }, url);
            //Verification
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

    }

}
