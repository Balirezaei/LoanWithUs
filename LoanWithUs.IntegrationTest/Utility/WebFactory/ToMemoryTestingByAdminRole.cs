namespace LoanWithUs.IntegrationTest.Utility.WebFactory
{
    public class ToMemoryTestingByAdminRole : ToTesting
    {
        public ToMemoryTestingByAdminRole() : base(WebFactoryType.InMemory, new TestUserLogined(StaticDate.AdministratorId, Common.Enum.LoanRole.Admin))
        {
        }
    }
}