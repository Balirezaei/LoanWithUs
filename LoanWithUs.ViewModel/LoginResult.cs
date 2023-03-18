using LoanWithUs.Common.Enum;

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
        public LoanRole Role { get; set; }
    }
}
