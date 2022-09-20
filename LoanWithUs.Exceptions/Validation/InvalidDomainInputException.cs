namespace LoanWithUs.Exceptions
{
    public class InvalidDomainInputException : DomainException
    {
        public InvalidDomainInputException(string input) : base (input)
        {
        }
      
    }

}