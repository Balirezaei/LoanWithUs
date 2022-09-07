namespace LoanWithUs.Domain.UserAggregate
{
    public class UserLogin
    {
        protected UserLogin() { }
        public DateTime ExpireDate { get; private set; }
        public string Code { get; private set; }

        public UserLogin(DateTime expireDate)
        {
            ExpireDate = expireDate;
            Code = GenerateCode();
        }
        private string GenerateCode()
        {
            return "1234";
        }
    }
}