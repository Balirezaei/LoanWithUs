using FluentAssertions;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.IntegrationTest.Utility.WebFactory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.IntegrationTest.InMemoryTests.ApiAutomation
{
    public  class ApplicantDashboardTest : IClassFixture<ToMemoryTestingByApplicantRole>
    {
        private readonly ToMemoryTestingByApplicantRole _toMemoryTesting;

        public ApplicantDashboardTest(ToMemoryTestingByApplicantRole toMemoryTesting)
        {
            _toMemoryTesting = toMemoryTesting;
        }
        
        [Fact]
        public async Task Applicant_On_GetInitDashboardInfo_Is_On_First_Ladder()
        {           

            //Exersice
            var response = await _toMemoryTesting.CallGetApi<ApplicantDashboard>(null, "/ApplicantDashboard/GetInfo");

            //Verification


            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var responseText = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApplicantDashboard>(responseText);

            result.CurrentLadder.Should().Be(1);
            
        }

    }
}
