using FluentAssertions;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Domain;
using LoanWithUs.IntegrationTest.Utility.WebFactory;
using LoanWithUs.ViewModel;
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


    }
}
