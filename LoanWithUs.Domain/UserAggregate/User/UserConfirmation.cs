namespace LoanWithUs.Domain
{
    public class UserConfirmation
    {
        public static UserConfirmation NotConfirmedInstance() {
            return new UserConfirmation();
            
        }
        protected UserConfirmation() { }
        public bool PersonalInformationConfirmation { get; private set; }
        public bool UserBanckAccountConfirmation { get; private set; }
        public bool MobileConfirmation { get; private set; }
        public bool HomePhoneConfirmation { get; private set; }
        public bool PostalCodeConfirmation { get; private set; }
        public bool TotalConfirmation { get; private set; }

        public UserConfirmation(bool personalInformationConfirmation, bool userBanckAccountConfirmation, bool mobileConfirmation, bool homePhoneConfirmation, bool postalCodeConfirmation)
        {
            PersonalInformationConfirmation = personalInformationConfirmation;
            UserBanckAccountConfirmation = userBanckAccountConfirmation;
            MobileConfirmation = mobileConfirmation;
            HomePhoneConfirmation = homePhoneConfirmation;
            PostalCodeConfirmation = postalCodeConfirmation;
            TotalConfirmation = personalInformationConfirmation && userBanckAccountConfirmation && mobileConfirmation && homePhoneConfirmation && postalCodeConfirmation;
        }
         
    }

   
    }