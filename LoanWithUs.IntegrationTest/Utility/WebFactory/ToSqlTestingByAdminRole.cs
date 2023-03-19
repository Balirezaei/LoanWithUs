namespace LoanWithUs.IntegrationTest.Utility.WebFactory
{
    public class ToSqlTestingByAdminRole : ToTesting
    {
        public ToSqlTestingByAdminRole() : base(WebFactoryType.SQL, new TestUserLogined(StaticDate.AdministratorId, Common.Enum.LoanRole.Admin))
        {

        }
    }
}