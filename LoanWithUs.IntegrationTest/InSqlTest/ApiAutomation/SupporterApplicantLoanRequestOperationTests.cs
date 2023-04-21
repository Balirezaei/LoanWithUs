using FluentAssertions;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.IntegrationTest.Utility.WebFactory;
using LoanWithUs.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.IntegrationTest.InSqlTest.ApiAutomation
{
    public class SupporterApplicantLoanRequestOperationTests : IClassFixture<ToSqlTestingBySupporterRole>
    {
        private readonly ToSqlTestingBySupporterRole _toTesting;

        public SupporterApplicantLoanRequestOperationTests(ToSqlTestingBySupporterRole toTesting)
        {
            _toTesting = toTesting;
        }

        [Fact]
        public async Task SupporterShouldReceiveLoanRequests()
        {
            await _toTesting.WithMockLoanRequestByApplicant();
            var url = "api/SupporterApplicantRequest/GetOpenRequests";

            var vm = new ApplicantOpenRequestGridVm() { PageSize = 10, PageNumber = 1 };

            var response =await _toTesting.CallGetApi<ApplicantOpenRequestGridVm>(vm, url);

            //Verification
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var responseText = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PagedListResult<ApplicantRequestGrid>>(responseText);
            result.List.Count.Should().Be(1);

        }

    }
}
