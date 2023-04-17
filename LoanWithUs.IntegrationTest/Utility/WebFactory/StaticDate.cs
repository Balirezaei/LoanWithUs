namespace LoanWithUs.IntegrationTest.Utility.WebFactory
{
    public static class StaticDate
    {
        public static int AdministratorId
        {
            get
            {
                return 1;
            }
        }
        public static int SupporterId
        {
            get
            {
                return 1;
            }
        }
        public static int ApplicantId
        {
            get
            {
                return 2;
            }
        }

        public static string SupporterNationalCode
        {
            get
            {
                return "0123456987";
            }
        }

        public static string SupporterMobileNumber
        {
            get
            {
                return "09121236548";
            }
        }

        public static string ApplicantMobileNumber
        {
            get
            {
                return "09381112233";
            }
        }
        public static int FirstStepLadderAmount
        {
            get
            {
                return 1000000;
            }
        }
    }
}
