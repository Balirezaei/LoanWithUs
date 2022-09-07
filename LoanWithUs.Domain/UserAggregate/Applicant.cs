namespace LoanWithUs.Domain.UserAggregate
{
    public class Applicant : User
    {
        protected Applicant() { }
        public Applicant(string mobileNumber)
        {
            this.IdentityInformation = new IdentityInformation(mobileNumber);
            this.UserLogins?.Add(new UserLogin(DateTime.Now.AddMinutes(2)));
        }
    }
}