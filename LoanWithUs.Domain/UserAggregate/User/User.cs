using LoanWithUs.Common;

namespace LoanWithUs.Domain
{
    /// <summary>
    /// کلاس پایه پشتیبان و درخواستگر
    /// </summary>
    public class User : AggregateRoot
    {
        public int Id { get; protected set; }
        /// <summary>
        /// اطلاعات هویتی
        /// </summary>
        public virtual IdentityInformation IdentityInformation { get; protected set; }
        /// <summary>
        /// اطلاعات پستی
        /// </summary>
        public virtual AddressInformation AddressInformation { get; protected set; }
        /// <summary>
        /// اطلاعات تحصیلی
        /// </summary>
        public virtual EducationalInformation EducationalInformation { get; protected set; }
        /// <summary>
        /// تاییده ادمین سیستم
        /// </summary>
        public virtual UserConfirmation UserConfirmation { get; protected set; }
        /// <summary>
        /// اطلاعات شخصی
        /// </summary>
        public virtual PersonalInformation PersonalInformation { get; protected set; }
        /// <summary>
        /// مستندات مورد نیاز
        /// </summary>
        public virtual List<UserDocument> UserDocuments { get; protected set; }
        public virtual List<BankAccountInformation> BankAccountInformations { get; set; }
        public bool HasCertificate { get { return UserConfirmation.TotalConfirmation; } }
        public virtual List<UserLogin> UserLogins { get; protected set; }

        public virtual List<Loan> Loans { get; set; }


        public DateTime RegisterationDate { get; protected set; }

        public UserLogin AddNewLogin(string userAgent, IDateTimeServiceProvider dateProvider)
        {
            var userLogin = new UserLogin(dateProvider.GetDate().AddMinutes(2), userAgent);
            UserLogins.Add(userLogin);
            return userLogin;
        }

        public string DisplayName()
        {
            if (this.PersonalInformation != null)
            {
                return $"{this.PersonalInformation.FirstName} {this.PersonalInformation.LastName}";
            }
            else
            {
                return $"{this.IdentityInformation.NationalCode}";
            }
        }

    }
}