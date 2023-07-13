using FluentAssertions;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.ApplicationService.Contract.Applicant;
using LoanWithUs.Domain;
using LoanWithUs.IntegrationTest.Utility.WebFactory;
using LoanWithUs.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.IntegrationTest.InSqlTest.ApiAutomation
{

    public class ApplicantInformationCompletionTest : IClassFixture<ToSqlTestingByApplicant>
    {
        private readonly ToSqlTestingByApplicant _toTesting;

        public ApplicantInformationCompletionTest(ToSqlTestingByApplicant toSqlTesting)
        {
            _toTesting = toSqlTesting;
        }



        /// <summary>
        /// تا قبل از تایید اطلاعات توسط ادمین درخواستگر بارها و بارها میتواند اطلاعات را ویرایش کند 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ApplicantCanChangePersonalInformationWithoutAdminConfirmation_With_All_Pass_Validation()
        {
            //Fixture Setup
            var vm = new ApplicantPersonalInformationVm
            {

                FirstName = "FirstName",
                LastName = "LastName",
                IsMarried = false,
                BirthDate = DateTime.Now.AddYears(30).Date,
                MinimumIncome = 10000000,
                ChildrenCount = 0,
                Job = "Develop",
                FatherFullName = "FatherFullName",
                MotherFullName = "MotherFullName",
                IdentityNumber = "12121",
                IsMale = false,
            };

            //Exersice
            var response = await _toTesting.CallPostApi<ApplicantPersonalInformationVm>(vm, "/InformationCompletion/UpdateApplicantPersonalInformation");

            //Verification
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var applicant = await _toTesting.FindAsync<Applicant>(_toTesting.CurrentUser.UserId);
            applicant.PersonalInformation.FirstName.Should().Be(vm.FirstName);
            applicant.PersonalInformation.LastName.Should().Be(vm.LastName);
            applicant.PersonalInformation.FatherFullName.Should().Be(vm.FatherFullName);
            applicant.PersonalInformation.MotherFullName.Should().Be(vm.MotherFullName);
            applicant.PersonalInformation.Job.Should().Be(vm.Job);
            applicant.PersonalInformation.MinimumIncome.Should().Be(vm.MinimumIncome);
            applicant.PersonalInformation.ChildrenCount.Should().Be(vm.ChildrenCount);
            applicant.PersonalInformation.BirthDate.Should().Be(vm.BirthDate.Date);


        }

        [Theory]
        [InlineData("FirstName", "ورود نام اجباری است.")]
        [InlineData("LastName", "ورود نام خانوادگی اجباری است.")]
        public async Task ApplicantShouldApplyValidationOnPersonalInformationCommand(string fieldName,string errorMessage)
        {
            //Fixture Setup
            var vm = new ApplicantPersonalInformationVm
            {

                FirstName = "FirstName",
                LastName = "LastName",
                IsMarried = false,
                BirthDate = DateTime.Now.AddYears(30).Date,
                MinimumIncome = 10000000,
                ChildrenCount = 0,
                Job = "Develop",
                FatherFullName = "FatherFullName",
                MotherFullName = "MotherFullName",
                IdentityNumber = "12121",
                IsMale = false,
            };

            vm.GetType().GetProperty(fieldName).SetValue(vm, null);
            //Exersice
            var response = await _toTesting.CallPostApi<ApplicantPersonalInformationVm>(vm, "/InformationCompletion/UpdateApplicantPersonalInformation");

            //Verification
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            var responseText = await response.Content.ReadAsStringAsync();
            responseText.Should().Contain("validation errors ");
            responseText.Should().Contain(errorMessage);

        }

        [Fact]
        public async Task ApplicantCanAddBanckAccount_On_Happy_Path()
        {
            //Fixture Setup
            var vm = new ApplicantBanckAccountInformationVm
            {

                BankCartNumber = "1231231231231231",
                BankType = Common.BankType.Tejarat,
                IsActive = true,
                ShabaNumber = "IR123123123123456456789"
            };

            //Exersice
            var response = await _toTesting.CallPostApi<ApplicantBanckAccountInformationVm>(vm, "/InformationCompletion/AddBanckAccount");

            //Verification
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var responseText = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ValidationProblemDetails>(responseText);

            var applicant = await _toTesting.FindAsync<Applicant>(_toTesting.CurrentUser.UserId);
            var savedBanckAccount = applicant.BankAccountInformations.First(m => m.ShabaNumber == vm.ShabaNumber);

            savedBanckAccount.Should().NotBeNull();
            savedBanckAccount.BankCartNumber.Should().Be(vm.BankCartNumber);
            savedBanckAccount.BankType.Should().Be(vm.BankType);

            //TearDown
            await _toTesting.CallPostApi<ApplicantRemoveBanckAccountInformationVm>(
                      new ApplicantRemoveBanckAccountInformationVm
                      {
                          ShabaNumber = vm.ShabaNumber
                      }, "/InformationCompletion/DeleteBanckAccount");
        }

        [Fact]
        public async Task ApplicantCanRemoveSavedBanckAccount()
        {
            //Fixture Setup
            var vm = new ApplicantBanckAccountInformationVm
            {

                BankCartNumber = "12312312312312315",
                BankType = Common.BankType.Tejarat,
                IsActive = true,
                ShabaNumber = "IR1231231231234564567895"
            };
            await _toTesting.CallPostApi<ApplicantBanckAccountInformationVm>(vm, "/InformationCompletion/AddBanckAccount");



            var response = await _toTesting.CallPostApi<ApplicantRemoveBanckAccountInformationVm>(
                       new ApplicantRemoveBanckAccountInformationVm
                       {
                           ShabaNumber = vm.ShabaNumber
                       }, "/InformationCompletion/DeleteBanckAccount");


            //Verification
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var applicant = await _toTesting.FindAsync<Applicant>(_toTesting.CurrentUser.UserId);
            var savedBanckAccount = applicant.BankAccountInformations.FirstOrDefault(m => m.ShabaNumber == vm.ShabaNumber);

            savedBanckAccount.Should().BeNull();
        }



        [Fact]
        public async Task ApplicantCanActiveSavedBanckAccount()
        {
            //Fixture Setup
            var vm1 = new ApplicantBanckAccountInformationVm
            {

                BankCartNumber = "12312312312312315",
                BankType = Common.BankType.Tejarat,
                IsActive = true,
                ShabaNumber = "IR1231231231234564567895"
            };
            await _toTesting.CallPostApi<ApplicantBanckAccountInformationVm>(vm1, "/InformationCompletion/AddBanckAccount");

            var vm2 = new ApplicantBanckAccountInformationVm
            {

                BankCartNumber = "123123123123123150",
                BankType = Common.BankType.Tejarat,
                IsActive = false,
                ShabaNumber = "IR12312312312345645678950"
            };
            await _toTesting.CallPostApi<ApplicantBanckAccountInformationVm>(vm2, "/InformationCompletion/AddBanckAccount");

            var activeVm = new ApplicantActiveBanckAccountInformationVm
            {
                ShabaNumber = vm2.ShabaNumber
            };

            var response = await _toTesting.CallPostApi<ApplicantActiveBanckAccountInformationVm>(activeVm
                       ,
                       "/InformationCompletion/ActiveBanckAccount");


            //Verification
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var applicant = await _toTesting.FindAsync<Applicant>(_toTesting.CurrentUser.UserId);
            var savedBanckAccount_1 = applicant.BankAccountInformations.FirstOrDefault(m => m.ShabaNumber == vm1.ShabaNumber);
            var savedBanckAccount_2 = applicant.BankAccountInformations.FirstOrDefault(m => m.ShabaNumber == vm2.ShabaNumber);

            savedBanckAccount_1.IsActive.Should().Be(false);
            savedBanckAccount_2.IsActive.Should().Be(true);

            //TearDown
            await _toTesting.CallPostApi<ApplicantRemoveBanckAccountInformationVm>(
                      new ApplicantRemoveBanckAccountInformationVm
                      {
                          ShabaNumber = vm1.ShabaNumber
                      },
                      "/InformationCompletion/DeleteBanckAccount");
        }

        [Fact]
        public async Task UpdateUserDocument()
        {
            var file = await _toTesting.WithMockFile();

            //UpdateDocumnets(List < ApplicantDocumentsVm > vm)
            var vm = new List<ApplicantDocumentsVm>
            {
              new ApplicantDocumentsVm  {FileId = file.Id }
            };
            var response = await _toTesting.CallPostApi<List<ApplicantDocumentsVm>>(vm, "/InformationCompletion/UpdateDocumnets");

            //Verification
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var applicant = await _toTesting.FindAsync<Applicant>(_toTesting.CurrentUser.UserId);

            applicant.UserDocuments.Count().Should().Be(1);

            //TearDawn
            vm = new List<ApplicantDocumentsVm>();
            await _toTesting.CallPostApi<List<ApplicantDocumentsVm>>(vm, "/InformationCompletion/UpdateDocumnets");
        }

        [Fact]
        public async Task GetCityWithoutProvince_Should_Return_Provinces()
        {
            var response = await _toTesting.CallGetApi("/InformationCompletion/GetAllProvince");

            var responseText = await response.Content.ReadAsStringAsync();
            
            //Verification
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var cities = JsonConvert.DeserializeObject<List<CityDto>>(responseText);

            cities.Any(m => m.ProvinceId != null).Should().BeFalse();
            cities.Count().Should().NotBe(0);
        }

        [Fact]
        public async Task GetCityWithProvince_Should_Return_City()
        {

            var provinceId = 8;//Tehran On DB Migration
            var response = await _toTesting.CallGetApi($"/InformationCompletion/GetAllCityWithProvince?provinceId={provinceId}");

            //Verification

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var responseText = await response.Content.ReadAsStringAsync();

            var cities = JsonConvert.DeserializeObject<List<CityDto>>(responseText);

            cities.All(m=>m.ProvinceId==provinceId).Should().BeTrue();
            cities.Count().Should().NotBe(0);
        }



    }
}
