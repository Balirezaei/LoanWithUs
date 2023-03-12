using FluentAssertions;
using LoanWithUs.ApplicationService.Contract.Administrator;
using LoanWithUs.Domain.UserAggregate;
using LoanWithUs.IntegrationTest.Utility.WebFactory;
using LoanWithUs.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.IntegrationTest.InMemoryTests.ApiAutomation
{
    public class AdministratorSupporterResistrationApiTests : IClassFixture<ToMemoryTesting>
    {
        private readonly ToMemoryTesting _toMemoryTesting;

        public AdministratorSupporterResistrationApiTests(ToMemoryTesting toMemoryTesting)
        {
            _toMemoryTesting = toMemoryTesting;
        }


        [Fact]
        public async Task Admin_Can_Register_Supporter()
        {
            //Setup         
            var vm = new AdminRegisterSupporterVm()
            {
                MobileNo = "09124566547",
                NationalCode = "1234567899"
            };

            //Exersice
            var response = await _toMemoryTesting.CallPostApi<AdminRegisterSupporterVm>(vm, "/RgisterSupporter");

            //Verification


            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var responseText = await response.Content.ReadAsStringAsync();



        }


    }
}
