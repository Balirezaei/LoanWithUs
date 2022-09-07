using System.Text.RegularExpressions;

namespace LoanWithUs.Exceptions
{
    public class MobileValidator
    {

        private static string Mobile_PATTERN = @"\+989\d{9}";

        private IValidationListener listener;

        public MobileValidator(IValidationListener listener)
        {
            this.listener = listener;
        }

        public void validate(string mobile)
        {
            if (!Regex.Matches(mobile, Mobile_PATTERN, RegexOptions.IgnorePatternWhitespace).Any())
            {
                listener.reject(new InvalidDomainInputException(mobile));
            }
        }
    }
}