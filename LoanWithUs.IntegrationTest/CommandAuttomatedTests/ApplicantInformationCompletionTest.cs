using FluentAssertions;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.IntegrationTest.Utility.WebFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.IntegrationTest
{
    public class ApplicantInformationCompletionTest : IClassFixture<ToSqlTestingByApplicant>
    {
        private readonly ToSqlTestingByApplicant _toSqlTesting;

        public ApplicantInformationCompletionTest(ToSqlTestingByApplicant toSqlTesting)
        {
            _toSqlTesting = toSqlTesting;
        }

        [Fact]
        public async Task UpdateEducationalInformation_Should_work_Properly_on_first_time()
        {
            var applicantId =  _toSqlTesting.CurrentUser.UserId;

            var result = await _toSqlTesting.SendAsync(new ApplicantCompleteEductionalInformationCommand
            {
                LastEducationLevel = Common.EducationLevel.Bachelor,

                EducationalSubject = "فناوری اطلاعات",
                ApplicantId = applicantId
            });

            result.Message.Should().NotBeEmpty();

        }


    }
}
