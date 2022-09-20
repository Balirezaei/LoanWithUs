using FluentAssertions;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.IntegrationTest.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.IntegrationTest
{
    public class ApplicantInformationCompletionTest:IClassFixture<ToSqlTesting>
    {
        private readonly ToSqlTesting _toSqlTesting;

        public ApplicantInformationCompletionTest(ToSqlTesting toSqlTesting)
        {
            _toSqlTesting = toSqlTesting;
        }
        
        [Fact]
        public async Task UpdateEducationalInformation_Should_work_Properly_on_first_time()
        {
            await _toSqlTesting.WithDefaultApplicant();

            var result = await _toSqlTesting.SendAsync(new ApplicantCompleteEductionalInformationCommand
            {
                LastEducationTitle = "لیسانس",
                
                EducationalSubject= "فناوری اطلاعات",
                Id=1
            });

            result.Message.Should().NotBeEmpty();


        }
    }
}
