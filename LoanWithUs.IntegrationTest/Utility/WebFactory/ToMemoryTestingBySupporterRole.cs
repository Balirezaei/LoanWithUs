namespace LoanWithUs.IntegrationTest.Utility.WebFactory
{
    public class ToMemoryTestingBySupporterRole : ToTesting
    {
        public ToMemoryTestingBySupporterRole() : base(WebFactoryType.InMemory, new TestUserLogined(StaticDate.SupporterId, Common.Enum.LoanRole.Supporter))
        {
        }
    }
}