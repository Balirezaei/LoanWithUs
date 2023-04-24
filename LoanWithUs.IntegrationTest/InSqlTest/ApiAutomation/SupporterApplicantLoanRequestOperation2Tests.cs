using FluentAssertions;
using LoanWithUs.IntegrationTest.Utility.WebFactory;
using LoanWithUs.ViewModel;
using System.Net;

namespace LoanWithUs.IntegrationTest.InSqlTest.ApiAutomation
{
    public class SupporterApplicantLoanRequestOperation2Tests : IClassFixture<ToSqlTestingBySupporterRole>
    {
        private readonly ToSqlTestingBySupporterRole _toTesting;

        public SupporterApplicantLoanRequestOperation2Tests(ToSqlTestingBySupporterRole toTesting)
        {
            _toTesting = toTesting;
            _toTesting.WithMockLoanRequestByApplicant().Wait();
        }


        [Fact]
        public async Task SupporterCanRejectLoanRequest()
        {
            var url = "/SupporterApplicantRequest/RejectRequest";
            var response = await _toTesting.CallPostApi<SupporterLoanRequestActionViewModel>(new SupporterLoanRequestActionViewModel { RequestId = 1 }, url);
            //Verification
            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }
    }

}
