namespace LoanWithUs.IntegrationTest.Utility.WebFactory
{
    public class ToSqlTestingByApplicant : ToTesting
    {
        public ToSqlTestingByApplicant():base(WebFactoryType.SQL, new TestUserLogined(StaticDate.ApplicantId, Common.Enum.LoanRole.Applicant))
        {

        }
    }
}