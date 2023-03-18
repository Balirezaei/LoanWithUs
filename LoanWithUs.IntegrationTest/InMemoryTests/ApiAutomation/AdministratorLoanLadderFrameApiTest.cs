using FluentAssertions;
using LoanWithUs.ApplicationService.Contract.Administrator;
using LoanWithUs.Domain;
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
    public class AdministratorLoanLadderFrameApiTest : IClassFixture<ToMemoryTestingByAdminRole>
    {
        private readonly ToMemoryTestingByAdminRole _toTesting;

        public AdministratorLoanLadderFrameApiTest(ToMemoryTestingByAdminRole toTesting)
        {
            _toTesting = toTesting;
        }

        [Fact]
        public async Task Admin_Can_Get_All_LoanLadderFrame()
        {
            //Setup         
            var vm = new LoanLadderFrameContractGridContractVm()
            {
                Order = "",
                PageNumber = 1,
                PageSize = 10,
                Sort = ""
            };

            //Exersice
            var response = await _toTesting.CallGetApi<LoanLadderFrameContractGridContractVm>(vm, "/LoanLadderFrame/Get");

            //Verification
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var responseText = await response.Content.ReadAsStringAsync();
            var loanFrameLadders = JsonConvert.DeserializeObject<List<LoanLadderFrameDto>>(responseText);

            loanFrameLadders.Count().Should().NotBe(0);
            loanFrameLadders.OrderBy(m=>m.Step).First().Step.Should().Be(1);
        }

        [Fact]
        public async Task Admin_insert_LoanLadderFrame_withCurrect_Info()
        {
            var cmd = new LoanLadderFrameCreateCommand 
            {
                Amount = new Common.DefinedType.Amount(100000 + new Random().Next(10000, 90000), Common.Enum.MoneyType.Toman),
                InstallmentCouts = new LoanLadderFrameInstallmentCountDto[] {
                    new LoanLadderFrameInstallmentCountDto(12),
                    new LoanLadderFrameInstallmentCountDto(6)},
                Step = 2,
                Title = "نردبان دوم"
            };

            var response = await _toTesting.CallPostApi<LoanLadderFrameCreateCommand >(cmd, "/LoanLadderFrame/Post");
            var responseText = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<LoanLadderFrameCreateCommandResult>(responseText);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Id.Should().NotBe(0);
        }

        [Fact]
        public async Task Installment_Can_Append_To_LoanLadderFrame()
        {
            var cmd = new LoanLadderFrameAppendInstallmentCommand
            {
                LoanLadderFrameId = 1,
                InstallmentCount=13
            };

            var response = await _toTesting.CallPostApi<LoanLadderFrameAppendInstallmentCommand>(cmd, "/LoanLadderFrame/AppendInstallment");
            var responseText = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<LoanLadderFrameCreateCommandResult>(responseText);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var loanLadderFrame= await _toTesting.FindAsync<LoanLadderFrame>(cmd.LoanLadderFrameId);
            loanLadderFrame.AvalableInstallments.Should().ContainSingle(m => m.Count == cmd.InstallmentCount);
        }

    }
}
