namespace LoanWithUs.IntegrationTest.Utility.WebFactory
{
    public class ToMemoryTestingByAdminRole : ToMemoryTesting
    {
        public ToMemoryTestingByAdminRole()
        {
            base.CurrentUser = new TestUserLogined(StaticDate.AdministratorId, Common.Enum.LoanRole.Admin);
        }
    }
}