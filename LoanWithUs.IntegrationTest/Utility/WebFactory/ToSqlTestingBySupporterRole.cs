namespace LoanWithUs.IntegrationTest.Utility.WebFactory
{
    public class ToSqlTestingBySupporterRole : ToSqlTesting
    {
        public ToSqlTestingBySupporterRole()
        {
            base.CurrentUser = new TestUserLogined(StaticDate.SupporterId, Common.Enum.LoanRole.Supporter);
        }
    }
}