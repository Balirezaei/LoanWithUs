namespace LoanWithUs.Domain.UserAggregate
{
    using LoanWithUs.Exceptions;
    public class BankAccountInformation
    {

        CommonTextInputValidator validator =
            new CommonTextInputValidator(new ExceptionThrowingListener());

        public BankAccountInformation() { }
        public string ShabaNumber { get; private set; }
        public string BankCartNumber { get; private set; }
        public string BankName { get; private set; }

        public BankAccountInformation(string shahbNumber, string bankCartNumber, string bankName)
        {

            this.ShabaNumber = shahbNumber;
            this.BankCartNumber = BankCartNumber = bankCartNumber;
            this.BankName = bankName;

        }
    }
}