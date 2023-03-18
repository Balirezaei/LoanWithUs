using FluentAssertions;
using LoanWithUs.Domain;
using LoanWithUs.IntegrationTest.Utility.WebFactory;
using LoanWithUs.Persistense.EF.ContextContainer;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.IntegrationTest.InSqlTest
{
    public class LoanLadderTest : IClassFixture<ToSqlTestingByAdminRole>
    {
        private readonly ToSqlTestingByAdminRole _toSqlTesting;

        public LoanLadderTest(ToSqlTestingByAdminRole toSqlTesting)
        {
            _toSqlTesting = toSqlTesting;
        }

        [Fact]
        public async Task Ladders_Have_One_Step_On_Db_Init()
        {
            var loanFrame = await _toSqlTesting.GetAsync<LoanLadderFrame>(_ => true);

            loanFrame.Count().Should().Be(1);
        }

        [Fact]
        public void Repetetive_Step_Are_NotAllowed_And_Receive_Exception()
        {
            var domainService = Substitute.For<ILoanLadderFrameDomainService>();
            domainService.IsStepRepetitive(default).ReturnsForAnyArgs(true);

            var builder = new LoanLadderFrameBuilder(domainService)
                               .WithTitle("نردبان اول")
                               .WithStep(1)
                               .WithTomanAmount(1000000);

            var stepOneDuplicate = () => builder.Build();

            stepOneDuplicate.Should().Throw<Exception>();
        }

    }
}
