namespace LoanWithUs.IntegrationTest.Utility.WebFactory
{
    public class ToMemoryTestingByApplicantRole : ToMemoryTesting
    {
        public ToMemoryTestingByApplicantRole()
        {
            base.CurrentUser = new TestUserLogined(StaticDate.ApplicantId, Common.Enum.LoanRole.Applicant);
        }
    }
}