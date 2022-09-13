namespace LoanWithUs.Exceptions
{
    public class InvalidDomainInputException : DomainException
    {
        public InvalidDomainInputException(string input) : base($"مقدار ورودی {input} به درستی وارد نشده است.")
        {
        }
    }
}