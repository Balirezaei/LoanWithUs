using LoanWithUs.Common;

namespace LoanWithUs.Domain.Test.Utility
{
    public class AdministratorBuilder
    {
        public Administrator Build()
        {
            IDateTimeServiceProvider dateProvider = new DateTimeServiceProvider();
            return new Administrator(1, "admin", "admin", "09121231234", "1234567891", "admin", "admin", dateProvider);
        }
    }
}
