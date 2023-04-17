using FluentAssertions;
using LoanWithUs.Domain.Test.Utility;
using LoanWithUs.Domain;

namespace LoanWithUs.Domain.Test
{
    public class UpdateBankInformationTest
    {
        //[Fact]
        //public void applicant_update_bank_information_create_exception_on_null_data()
        //{
        //    Applicant applicant = new ApplicantBuilder().Build();
        //    Action result = () =>
        //    {
        //        applicant.UpdateBankInformation(null);
        //    };
        //    result.Should().Throw<InvalidDomainInputException>();
        //}


        //[Fact]
        //public void applicant_throw_exception_on_invalid_card_number()
        //{
        //    var expectedCardNumber = "%#15l28";
        //    var expectedBankName = Common.BankName.Saman;

        //    Applicant applicant = new ApplicantBuilder().Build();
        //    List<string> errors = new List<string>();

        //    //Excersice
        //    Action comparison = () =>
        //    {
        //        applicant.UpdateBankInformation( );
        //    };

        //    //Assertion
        //    comparison.Should().Throw<InvalidDomainInputException>();
        //}

        [Fact]

        public void Bank_Info_updates_with_correct_info()
        {
            var expectedShahabNumber = "12456987";
            var expectedBandCardNumber = "1234567891234567";
            var expectedBankName = Common.BankType.Ayandeh;

            Applicant applicant = new ApplicantBuilder().Build();
            applicant.UpdateBankInformation(expectedShahabNumber, expectedBandCardNumber, expectedBankName);

            applicant.BankAccountInformations.Should().HaveCount(1);
            applicant.BankAccountInformations.First().ShabaNumber.Should().Be(expectedShahabNumber);
            applicant.BankAccountInformations.First().BankCartNumber.Should().Be(expectedBandCardNumber);
            applicant.BankAccountInformations.First().BankType.Should().Be(expectedBankName);

        }
    }
}