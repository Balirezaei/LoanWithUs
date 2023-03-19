namespace LoanWithUs.IntegrationTest.Utility.WebFactory
{
    public class ToSqlTestingBySupporterRole : ToTesting
    {
        public ToSqlTestingBySupporterRole() : base(WebFactoryType.SQL, new TestUserLogined(StaticDate.SupporterId, Common.Enum.LoanRole.Supporter))
        {
            //base.CurrentUser = new TestUserLogined(StaticDate.SupporterId, Common.Enum.LoanRole.Supporter);
        }
    }
}