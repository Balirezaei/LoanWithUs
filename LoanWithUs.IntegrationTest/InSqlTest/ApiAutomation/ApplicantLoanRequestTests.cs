using FluentAssertions;
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
    public class ApplicantLoanRequestTests : IClassFixture<ToSqlTestingByApplicant>
    {
        private readonly ToSqlTestingByAdminRole _toTesting;

        public ApplicantLoanRequestTests(ToSqlTestingByAdminRole toSqlTesting)
        {
            _toTesting = toSqlTesting;
        }


        [Fact]
        public async Task QulifiedApplicant_With_Valid_Supporter_On_First_Ladder_Get_Corresponding_Info_Of_Loan()
        {
            //  api/LoanRequest/GetLatestLoanStatus
            throw new NotImplementedException();
        }

        [Fact]
        public async Task QulifiedApplicant_With_Insufficient_Supporter_Credit_On_First_Ladder_Get_Corresponding_Info_Of_Loan()
        {

            throw new NotImplementedException();
        }


        [Fact]
        public async Task QulifiedApplicant_With_With_Valid_Supporter_Credit_With_Active_Loan_Request_Get_Corresponding_Info()
        {

            throw new NotImplementedException();
        }

        //[Fact]
        //public async Task QulifiedApplicant_On_First_Ladder_CanRequestLoan()
        //{
        //    //Setup         
        //    var vm = new LoanLadderFrameContractGridContractVm()
        //    {
        //        Order = "",
        //        PageNumber = 1,
        //        PageSize = 10,
        //        Sort = ""
        //    };

        //    //Exersice
        //    var response = await _toTesting.CallGetApi<LoanLadderFrameContractGridContractVm>(vm, "/LoanLadderFrame/Get");

        //    //Verification
        //    response.StatusCode.Should().Be(HttpStatusCode.OK);
        //    var responseText = await response.Content.ReadAsStringAsync();
        //    var loanFrameLadders = JsonConvert.DeserializeObject<List<LoanLadderFrameDto>>(responseText);

        //    loanFrameLadders.Count().Should().NotBe(0);
        //    loanFrameLadders.OrderBy(m => m.Step).First().Step.Should().Be(1);

        //}
    }
}
