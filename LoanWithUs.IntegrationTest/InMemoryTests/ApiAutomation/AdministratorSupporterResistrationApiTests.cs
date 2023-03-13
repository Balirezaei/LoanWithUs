using FluentAssertions;
using LoanWithUs.ApplicationService.Contract.Administrator;
using LoanWithUs.Common.DefinedType;
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
    public class AdministratorSupporterResistrationApiTests : IClassFixture<ToMemoryTestingByAdminRole>
    {
        private readonly ToMemoryTestingByAdminRole _toMemoryTesting;

        public AdministratorSupporterResistrationApiTests(ToMemoryTestingByAdminRole toMemoryTesting)
        {
            _toMemoryTesting = toMemoryTesting;
        }


        [Fact]
        public async Task Admin_Can_Register_Supporter()
        {
            //Setup         
            var vm = new AdminRegisterSupporterVm()
            {
                MobileNumber = new MobileNumber("09124566547"),
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
