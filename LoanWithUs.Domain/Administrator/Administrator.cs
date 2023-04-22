using LoanWithUs.Common;
using LoanWithUs.Common.DefinedType;
using LoanWithUs.Common.Enum;

namespace LoanWithUs.Domain
{
    /// <summary>
    /// کاربر ادمین سامانه
    /// </summary>
    public class Administrator
    {
        protected Administrator() { }
        public Administrator(int id, string firstName, string lastName, string mobileNumber, string nationalCode, string userName, string password, IDateTimeServiceProvider dateProvider)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.MobileNumber = mobileNumber;
            this.NationalCode = nationalCode;
            this.UserName = userName;
            this.Password = password;
            this.RegisterationDate = dateProvider.GetDate();
        }

        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string MobileNumber { get; private set; }
        public string NationalCode { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public virtual List<UserLogin> UserLogins { get; protected set; }
        public DateTime RegisterationDate { get; protected set; }

        public UserLogin AddNewAttempdToLogin(string userAgent, IDateTimeServiceProvider dateProvider)
        {
            var userLogin = new UserLogin(dateProvider.GetDate().AddMinutes(2), userAgent);
            this.UserLogins.Add(userLogin);
            return userLogin;
        }
        public string FullName()
        {
            return this.FirstName + " " + this.LastName;
        }

        public Supporter DefineNewSupporter(string nationalCode, MobileNumber mobileNumber, Amount initCredit, ISupporterDomainService supporterDomainService, IDateTimeServiceProvider dateProvider)
        {
            return new Supporter(nationalCode, mobileNumber, initCredit, supporterDomainService, dateProvider);
        }

        public Applicant ConfirmApplicant(Applicant applicant)
        {
            applicant.ConfirmInfo();
            return applicant;
        }
    }

}
