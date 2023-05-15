namespace LoanWithUs.Domain
{
    public class UserConfirmation
    {
        public static UserConfirmation NotConfirmedInstance() {
            return new UserConfirmation();
            
        }
        protected UserConfirmation() { }
        public bool NationalCodeConfirmation { get; private set; }
        public bool UserBanckAccountConfirmation { get; private set; }
        public bool MobileConfirmation { get; private set; }
        public bool HomePhoneConfirmation { get; private set; }
        public bool PostalCodeConfirmation { get; private set; }
        public bool TotalConfirmation { get; private set; }

        public UserConfirmation(bool nationalCodeConfirmation, bool userBanckAccountConfirmation, bool mobileConfirmation, bool homePhoneConfirmation, bool postalCodeConfirmation)
        {
            NationalCodeConfirmation = nationalCodeConfirmation;
            UserBanckAccountConfirmation = userBanckAccountConfirmation;
            MobileConfirmation = mobileConfirmation;
            HomePhoneConfirmation = homePhoneConfirmation;
            PostalCodeConfirmation = postalCodeConfirmation;
            TotalConfirmation = nationalCodeConfirmation && userBanckAccountConfirmation && mobileConfirmation && homePhoneConfirmation && postalCodeConfirmation;
        }
    }
}