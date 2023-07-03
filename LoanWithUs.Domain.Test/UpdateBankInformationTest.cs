using FluentAssertions;
using LoanWithUs.Domain.Test.Utility;
using LoanWithUs.Domain;
using FluentAssertions.Common;
using LoanWithUs.Exceptions;
using LoanWithUs.Resources;

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
            applicant.AddBankInformation(expectedShahabNumber, expectedBandCardNumber, expectedBankName,true);

            applicant.BankAccountInformations.Should().HaveCount(1);
            var savedBanckAccount = applicant.BankAccountInformations.First(m => m.ShabaNumber == expectedShahabNumber);
            savedBanckAccount.ShabaNumber.Should().Be(expectedShahabNumber);
            savedBanckAccount.BankCartNumber.Should().Be(expectedBandCardNumber);
            savedBanckAccount.BankType.Should().Be(expectedBankName);
        }

        [Fact]
        public void On_Add_Extra_Banck_Account_should_recived_Exception()
        {
            var expectedShahabNumber = "12456987";
            var expectedBandCardNumber = "1234567891234567";
            var expectedBankName = Common.BankType.Ayandeh;

            Applicant applicant = new ApplicantBuilder().Build();
            applicant.AddBankInformation(expectedShahabNumber, expectedBandCardNumber, expectedBankName, true);
            applicant.AddBankInformation(expectedShahabNumber +"12", expectedBandCardNumber + "12", expectedBankName, true);
            applicant.AddBankInformation(expectedShahabNumber +"123", expectedBandCardNumber + "123", expectedBankName, true);

            //Excersice
            Action comparison = () =>
            {
                applicant.AddBankInformation(expectedShahabNumber + "1234", expectedBandCardNumber + "1234", expectedBankName, true);
            };

            //Assertion
            comparison.Should().Throw<DomainException>().WithMessage(Messages.ExceptionOnExtraBanckAccount);
        }

        [Fact]
        public void On_Add_Repetetive_Banck_Account_should_recived_Exception()
        {
            var expectedShahabNumber = "12456987";
            var expectedBandCardNumber = "1234567891234567";
            var expectedBankName = Common.BankType.Ayandeh;

            Applicant applicant = new ApplicantBuilder().Build();
            applicant.AddBankInformation(expectedShahabNumber, expectedBandCardNumber, expectedBankName, true);

            //Excersice
            Action comparison = () =>
            {
                applicant.AddBankInformation(expectedShahabNumber , expectedBandCardNumber , expectedBankName, true);
            };

            //Assertion
            comparison.Should().Throw<DomainException>().WithMessage(Messages.ExceptionOnRepetetiveBanck);
        }
    }
}