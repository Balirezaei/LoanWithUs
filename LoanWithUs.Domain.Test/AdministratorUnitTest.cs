using FluentAssertions;
using LoanWithUs.Common.DefinedType;
using LoanWithUs.Domain.Test.Utility;
using LoanWithUs.Domain;
using LoanWithUs.Exceptions;
using NSubstitute;
using LoanWithUs.Common;
using LoanWithUs.Common.ExtentionMethod;

namespace LoanWithUs.Domain.Test
{
    public class AdministratorUnitTest
    {
        IDateTimeServiceProvider dateProvider;

        public AdministratorUnitTest()
        {
            dateProvider = new DateTimeServiceProvider();
        }

        [Fact]
        public void Admin_should_create_Supporter_Successfully()
        {
            var admin = new AdministratorBuilder().Build();
            var suporterNationalCode = "1234567891";
            var suporterMobileNumber = new MobileNumber("09121231212");
            var domainSupporter = Substitute.For<ISupporterDomainService>();

            var supporet = admin.DefineNewSupporter(suporterNationalCode, suporterMobileNumber, StaticDataForBegining.InitCreditForSupporter.ToToman(), domainSupporter, dateProvider);

            supporet.IdentityInformation.MobileNumber.Should().Be(suporterMobileNumber);
            supporet.IdentityInformation.NationalCode.Should().Be(suporterNationalCode);
            supporet.GetAvailableCredit().amount.Should().Be(StaticDataForBegining.InitCreditForSupporter);
        }

        [Fact]
        public void Admin_DefineNewSupporter_Should_Throw_Exception_With_InvalidInput()
        {
            var admin = new AdministratorBuilder().Build();
            var suporterNationalCode = "1234567891";
            MobileNumber suporterMobileNumber = new MobileNumber("0");
            var domainSupporter = Substitute.For<ISupporterDomainService>();

            var action = () =>
            {
                admin.DefineNewSupporter(suporterNationalCode, suporterMobileNumber, StaticDataForBegining.InitCreditForSupporter.ToToman(), domainSupporter, dateProvider);
            };

            action.Should().Throw<InvalidDomainInputException>();
        }



    }
}
