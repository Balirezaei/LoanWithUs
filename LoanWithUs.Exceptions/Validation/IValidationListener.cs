namespace LoanWithUs.Exceptions
{
    public interface IValidationListener
    {
        void reject(System.Exception reason);
    }
}