using FluentAssertions;
using LoanWithUs.Domain.Test.Utility;
using LoanWithUs.Domain.UserAggregate;
using LoanWithUs.Exceptions;
namespace LoanWithUs.Domain.Test
{
    
    public class UpdateBankInformationTest
    {
        [Fact]
        public void applicant_update_bank_information_create_exception_on_null_data()
        {
            Applicant applicant = new ApplicantBuilder().Build();
            Action result = () =>
            {
                applicant.UpdateBankInformation(null);
            };
            result.Should().Throw<InvalidDomainInputException>();
        }


        [Fact]
        public void applicant_throw_exception_on_invalid_card_number()
        {
            var expectedCardNumber = "%#15l28";
            var expectedBankName = Common.BankName.Saman;

            Applicant applicant = new ApplicantBuilder().Build();
            List<string> errors = new List<string>();

            //Excersice
            Action comparison = () =>
            {
                applicant.UpdateBankInformation( );
            };

            //Assertion
            comparison.Should().Throw<InvalidDomainInputException>();
        }

        [Fact]

        public void applicant_works_correctly_on_updating_data()
        {
            var expectedShahabNumber = "12456987";
            var expectedBandCardNumber = "1245789631254";
            var expectedBankName = Common.BankName.Ayandeh;

            Applicant applicant = new ApplicantBuilder().WithDefaultBankInformation().Build();
            
        }
    }
}
