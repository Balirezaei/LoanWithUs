namespace LoanWithUs.IntegrationTest.Utility.WebFactory
{
    public class ToSqlTestingByAdminRole : ToSqlTesting
    {
        public ToSqlTestingByAdminRole()
        {
            base.CurrentUser = new TestUserLogined(StaticDate.AdministratorId, Common.Enum.LoanRole.Admin);
        }
    }
}