using LoanWithUs.Common.DefinedType;
using System.Text.RegularExpressions;

namespace LoanWithUs.Exceptions
{
    public class MobileValidator
    {

        private static string Mobile_PATTERN = @"09\d{9}";

        private IValidationListener listener;

        public MobileValidator(IValidationListener listener)
        {
            this.listener = listener;
        }

        public void validate(MobileNumber mobile)
        {
            if (!Regex.Matches(mobile.mobileNumber, Mobile_PATTERN, RegexOptions.IgnorePatternWhitespace).Any())
            {
                listener.reject(new InvalidDomainInputException("مقدار ورودی شماره تلفن به درستی وارد نشده است."));
            }
        }
    }
}