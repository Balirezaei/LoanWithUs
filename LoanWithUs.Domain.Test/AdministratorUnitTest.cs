using FluentAssertions;
using LoanWithUs.Domain.Test.Utility;
using LoanWithUs.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.Domain.Test
{
    public class AdministratorUnitTest
    {
        [Fact]
        public void Admin_should_create_Supporter_Successfully()
        {
            var admin = new AdministratorBuilder().Build();
            var suporterNationalCode = "1234567891";
            var suporterMobileNumber = "09121231212";

            var supporet = admin.DefineNewSupporter(suporterNationalCode, suporterMobileNumber);
           
            supporet.IdentityInformation.MobileNumber.Should().Be(suporterMobileNumber);
            supporet.IdentityInformation.NationalCode.Should().Be(suporterNationalCode);
            supporet.GetAvailableCredit().Should().Be(StaticDataForBegining.InitCreditForSupporter);
        }
        
        [Fact]
        public void Admin_DefineNewSupporter_Should_Throw_Exception_With_InvalidInput()
        {
            var admin = new AdministratorBuilder().Build();
            var suporterNationalCode = "1234567891";
            var suporterMobileNumber = "0";
            var action = () => {
                admin.DefineNewSupporter(suporterNationalCode, suporterMobileNumber);
            };

            action.Should().Throw<InvalidDomainInputException>();
        }


    }
}
