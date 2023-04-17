namespace LoanWithUs.Domain
{
    public class UserLogin
    {
        protected UserLogin() { }
        public DateTime ExpireDate { get; private set; }
        public string Code { get; private set; }
        public Guid Key { get; private set; }
        public string UserAgent { get; private set; }

        public UserLogin(DateTime expireDate, string userAgent)
        {
            ExpireDate = expireDate;
            Key = Guid.NewGuid();
            Code = GenerateCode();
            UserAgent = userAgent;
        }
        private string GenerateCode()
        {
            return "1234";
        }
    }
}