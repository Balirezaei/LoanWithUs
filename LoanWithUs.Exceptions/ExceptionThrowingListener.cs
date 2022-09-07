
namespace LoanWithUs.Exceptions
{
    public class ExceptionThrowingListener : IValidationListener
    {
        public void reject(System.Exception reason)
        {
            throw reason;
        }
    }
}