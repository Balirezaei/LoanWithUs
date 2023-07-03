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
        public bool IsActive { get; internal set; }

        internal BankAccountInformation(string shahbNumber, string bankCartNumber, BankType bankType,bool isActive)
        {

            ShabaNumber = shahbNumber;
            BankCartNumber = BankCartNumber = bankCartNumber;
            BankType = bankType;
            IsActive = isActive;
        }
    }
}