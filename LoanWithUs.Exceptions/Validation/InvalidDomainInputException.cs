namespace LoanWithUs.Exceptions
{
    public class InvalidDomainInputException : System.Exception
    {
        public InvalidDomainInputException(string input) : base($"مقدار ورودی {input} به درستی وارد نشده است.")
        {
        }
    }
}