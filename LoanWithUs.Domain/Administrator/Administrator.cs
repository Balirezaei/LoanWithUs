using LoanWithUs.Domain.UserAggregate;

namespace LoanWithUs.Domain
{
    /// <summary>
    /// کاربر ادمین سامانه
    /// </summary>
    public class Administrator
    {

        protected Administrator() { }
        public Administrator(int id, string firstName, string lastName, string mobileNumber, string nationalCode, string userName, string password)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.MobileNumber = mobileNumber;
            this.NationalCode = nationalCode;
            this.UserName = userName;
            this.Password = password;
            this.RegisterationDate = DateTime.Now;
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

        public UserLogin AddNewAttempdToLogin(string userAgent)
        {
            var userLogin = new UserLogin(DateTime.Now.AddMinutes(2), userAgent);
            this.UserLogins.Add(userLogin);
            return userLogin;
        }
        public string FullName()
        {
            return this.FirstName + " " + this.LastName;
        }

        public Supporter DefineNewSupporter(string nationalCode, string mobileNumber,ISupporterDomainService supporterDomainService)
        {
            return new Supporter(nationalCode, mobileNumber, new SupporterCredit(StaticDataForBegining.InitCreditForSupporter, MoneyUnit.NewToman()), supporterDomainService);
        }
    }

}
