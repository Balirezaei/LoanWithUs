namespace LoanWithUs.IntegrationTest.Utility.WebFactory
{
    public class ToMemoryTestingBySupporterRole : ToMemoryTesting
    {
        public ToMemoryTestingBySupporterRole()
        {
            base.CurrentUser = new TestUserLogined(StaticDate.SupporterId, Common.Enum.LoanRole.Supporter);
        }
    }
}