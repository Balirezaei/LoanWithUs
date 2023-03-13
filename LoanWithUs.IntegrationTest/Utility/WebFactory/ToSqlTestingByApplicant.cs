namespace LoanWithUs.IntegrationTest.Utility.WebFactory
{
    public class ToSqlTestingByApplicant : ToSqlTesting
    {
        public ToSqlTestingByApplicant()
        {
            base.CurrentUser = new TestUserLogined(StaticDate.ApplicantId, Common.Enum.LoanRole.Applicant);
        }
    }
}