namespace LoanWithUs.Domain.UserAggregate
{
    public class UserConfirmation
    {
        protected UserConfirmation() { }
        public bool NationalCodeConfirmation { get; private set; }
        public bool UserBanckAccountConfirmation { get; private set; }
        public bool MobileConfirmation { get; private set; }
        public bool HomePhoneConfirmation { get; private set; }
        public bool PostalCodeConfirmation { get; private set; }
        public bool TotalConfirmation { get; private set; }
    }
}