namespace LoanWithUs.IntegrationTest.Utility.WebFactory
{
    public class ToMemoryTestingByApplicantRole : ToTesting
    {
        public ToMemoryTestingByApplicantRole() : base(WebFactoryType.InMemory, new TestUserLogined(StaticDate.ApplicantId, Common.Enum.LoanRole.Applicant))
        {
            //base.CurrentUser = ;
        }
    }
}