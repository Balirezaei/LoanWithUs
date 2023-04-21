using FluentAssertions;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.ApplicationService.Contract.Administrator;
using LoanWithUs.IntegrationTest.Utility.WebFactory;
using LoanWithUs.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.IntegrationTest.InMemoryTests.ApiAutomation
{
    public class SupporterRegisterApplicantTest : IClassFixture<ToMemoryTestingBySupporterRole>
    {
        private readonly ToMemoryTestingBySupporterRole _toTesting;

        public SupporterRegisterApplicantTest(ToMemoryTestingBySupporterRole toMemoryTesting)
        {
            _toTesting = toMemoryTesting;
        }

        [Fact]
        public async Task Supporter_Can_Get_All_RegisteredApplicant()
        {
            //Setup         
            var vm = new RegisteredApplicantGridVm()
            {
                Order = "",
                PageNumber = 1,
                PageSize = 10,
                Sort = ""
            };

            //Exersice
            var response = await _toTesting.CallGetApi<RegisteredApplicantGridVm>(vm, "/RegisterApplicant");

            //Verification
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var responseText = await response.Content.ReadAsStringAsync();
            var loanFrameLadders = JsonConvert.DeserializeObject<PagedListResult<RegisteredApplicantDto>>(responseText);

            loanFrameLadders.List.Count().Should().NotBe(0);
        }

        [Fact]
        public async Task Register_Applicant_With_Currect_info()
        {
            //Setup         
            var vm = new SupporterRegistereApplicantVm()
            {
                MobileNumber = "09184566547",
                NationalCode = "1134567899",
                FirstName= "FirstName",
                LastName= "LastName"
            };

            //Exersice
            var response = await _toTesting.CallPostApi<SupporterRegistereApplicantVm>(vm, "/RegisterApplicant");

            //Verification

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var responseText = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SupporterRegistereApplicantCammandResult>(responseText);
            result.Should().NotBeNull();
            result.ApplicantId.Should().NotBe(0);
            
        }

    }
}
