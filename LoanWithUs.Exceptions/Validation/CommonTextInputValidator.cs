using System.Text.RegularExpressions;

namespace LoanWithUs.Exceptions
{
    public class CommonTextInputValidator
    {

        //private static string CommonText_PATTERN = @"^[^0-9]+$";
        private static string CommonText_PATTERN = @"[\u0600-\u06FF\s]+$";
      

        private IValidationListener listener;

        public CommonTextInputValidator(IValidationListener listener)
        {
            this.listener = listener;
        }

        public void validate(string input,string inputTitle)
        {
            if (input == null || !Regex.Matches(input, CommonText_PATTERN, RegexOptions.IgnorePatternWhitespace).Any())
            {
                listener.reject(new InvalidDomainInputException("مقدار ورودی"));
            }
        }
    }
}