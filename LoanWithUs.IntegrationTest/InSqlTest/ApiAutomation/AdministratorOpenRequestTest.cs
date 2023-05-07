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

namespace LoanWithUs.IntegrationTest
{
    public class AdministratorOpenLoanRequestTest : IClassFixture<ToSqlTestingByAdminRole>
    {
        private readonly ToSqlTestingByAdminRole _toTesting;

        public AdministratorOpenLoanRequestTest(ToSqlTestingByAdminRole toTesting)
        {
            _toTesting = toTesting;
        }

        //[Fact]
        //public async Task AdminCanGetOpenLoanRequest()
        //{
        //    throw new NotImplementedException();
        //}

        [Fact]
        public async Task AdminCanViewOpenApplicantLoanRequests()
        {
            //Fixture Setup
            var loanRequest = await _toTesting.WithMockLoanRequestByApplicant();
            await _toTesting.SupporterConfirmApplicantLoanRequest(loanRequest.LoanRequestId);

            //Exersice
            var response = await _toTesting.CallGetApi<ApplicantOpenRequestGridVm>(new ApplicantOpenRequestGridVm { PageSize = 10, PageNumber = 1 }, "/AdminLoanRequestManagement/GetSupporterOpenRequests");

            //Verification
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var responseText = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PagedListResult<AdminApplicantRequestGrid>>(responseText);

            result.TotalCount.Should().Be(1);

            //TearDawn
            await _toTesting.RemoveApplicantLoanRequest(loanRequest.LoanRequestId);

        }


    }
}
