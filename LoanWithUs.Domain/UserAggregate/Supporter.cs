namespace LoanWithUs.Domain.UserAggregate
{
    public class Supporter : User
    {

        public static void DefineNewSupporterByAdministrator(Administrator creator, string nationalCode, string mobileNumber)
        {
            new Supporter()
            {
                IdentityInformation = new IdentityInformation(mobileNumber, nationalCode)
            };
        }

        private Supporter()
        {

        }

    }
    public class SupporterCredit
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public long Amount { get; set; }
    }
}