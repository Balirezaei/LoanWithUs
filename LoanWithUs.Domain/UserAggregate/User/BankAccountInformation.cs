namespace LoanWithUs.Domain
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

            ShabaNumber = shahbNumber;
            BankCartNumber = BankCartNumber = bankCartNumber;
            BankType = bankType;

        }
    }
}