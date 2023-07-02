using FluentAssertions;
using LoanWithUs.IntegrationTest.Utility.WebFactory;
using LoanWithUs.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace LoanWithUs.IntegrationTest.InSqlTest.ApiAutomation
{
    public class ApplicantInformationCompletionOnConfirmedStateTest : IClassFixture<ToSqlTestingByApplicant>
    {
        private readonly ToSqlTestingByApplicant _toTesting;

        public ApplicantInformationCompletionOnConfirmedStateTest(ToSqlTestingByApplicant toSqlTesting)
        {
            _toTesting = toSqlTesting;
        }

        /// <summary>
        /// بعد از تایید اطلاعات توسط ادمین امکان ویرایش اطلاعات وجود ندارد
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [Fact]
        public async Task ApplicantCanNotChangePersonalInformationAfterAdminConfirmation()
        {
            await _toTesting.ConfirmApplicant();
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
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var responseText = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ValidationProblemDetails>(responseText);
            result.Title.Should().Be(Resources.Messages.ExceptionOnUpdateConfirmedApplicant);
        }

    }
}
