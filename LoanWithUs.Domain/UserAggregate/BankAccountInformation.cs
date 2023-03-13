namespace LoanWithUs.Domain.UserAggregate
{
    using LoanWithUs.Common;
    using LoanWithUs.Exceptions;
    public class BankAccountInformation
    {

        //CommonTextInputValidator validator =
        //    new CommonTextInputValidator(new ExceptionThrowingListener());

        public BankAccountInformation() { }
        public string ShabaNumber { get; private set; }
        public string BankCartNumber { get; private set; }
        public BankType BankType { get; private set; }

        internal BankAccountInformation(string shahbNumber, string bankCartNumber, BankType bankType)
        {

            this.ShabaNumber = shahbNumber;
            this.BankCartNumber = BankCartNumber = bankCartNumber;
            this.BankType = bankType;

        }
    }
}