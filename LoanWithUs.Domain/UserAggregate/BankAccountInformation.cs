namespace LoanWithUs.Domain.UserAggregate
{
    public class BankAccountInformation
    {
        protected BankAccountInformation() { }
        public string ShabaNumber { get; private set; }
        public string BankCartNumber { get; private set; }
        public string BankName { get; private set; }
    }
}