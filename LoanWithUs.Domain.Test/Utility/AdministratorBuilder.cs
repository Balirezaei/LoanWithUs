namespace LoanWithUs.Domain.Test.Utility
{
    public class AdministratorBuilder
    {
        public Administrator Build()
        {
            return new Administrator(1, "admin", "admin", "09121231234", "1234567891", "admin", "admin");
        }
    }
}