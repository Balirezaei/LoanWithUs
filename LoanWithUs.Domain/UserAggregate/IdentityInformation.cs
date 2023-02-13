
using LoanWithUs.Exceptions;
using System.Text.RegularExpressions;

namespace LoanWithUs.Domain.UserAggregate
{
    public class IdentityInformation
    {
        protected IdentityInformation() { }
        MobileValidator validator = new MobileValidator(new ExceptionThrowingListener());
        public IdentityInformation(string mobileNumber,string nationalCode)
        {
            validator.validate(mobileNumber);
            MobileNumber = mobileNumber;
        }

 


        public string NationalCode { get; private set; }
        public string MobileNumber { get; private set; }
        public string Password { get; private set; }
        public string EmailAddress { get; private set; }

    }

  
 
}