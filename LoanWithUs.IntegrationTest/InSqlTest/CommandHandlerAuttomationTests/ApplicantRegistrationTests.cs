using FluentAssertions;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common.DefinedType;
using LoanWithUs.Domain;
using LoanWithUs.IntegrationTest.Utility.WebFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.IntegrationTest.InSqlTest.CommandHandlerAuttomationTests
{
    public class ApplicantRegistrationTests : IClassFixture<ToSqlTestingBySupporterRole>
    {
        private readonly ToSqlTestingBySupporterRole _testing;

        public ApplicantRegistrationTests(ToSqlTestingBySupporterRole toSqlTesting)
        {
            _testing = toSqlTesting;
        }

        [Fact]
        public async Task Applicant_Who_Is_Registered_Have_The_First_Step_Of_ladder()
        {
            var supporterId = _testing.CurrentUser.UserId;


            //Exersice
            var result = await _testing.SendAsync(new SupporterRegistereApplicantCommand()
            {
                FirstName = "FirstName",
                LastName = "LastName",
                MobileNumber = new MobileNumber("09366551111"),
                NationalCode = "1188776655",
                SupporterId = supporterId
            });


            //Assertion
            var applicant =  (await _testing.GetAsync<Applicant>(m=>m.Id== result.ApplicantId, new string[] { "CurrentLoanLadderFrame" })).FirstOrDefault();
            
            applicant.CurrentLoanLadderFrame.Step.Should().Be(1);
        }
    }
}
