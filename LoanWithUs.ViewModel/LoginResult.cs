namespace LoanWithUs.ViewModel
{
    public class LoginResult
    {
        public LoginResult(bool isValid,string jWT)
        {
            this.JWT = jWT;
            this.IsValid = isValid;
        }

        public string JWT { get; set; }
        public bool IsValid { get; set; }
    }
}
