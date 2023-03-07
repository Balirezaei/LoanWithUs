using LoanWithUs.Common.Enum;

namespace LoanWithUs.IntegrationTest.Utility
{
    public class TestUserLogined
    {
        public int UserId { get; set; }
        public LoanRole Role { get; set; }

        public TestUserLogined(int userId, LoanRole role)
        {
            UserId = userId;
            Role = role;
        }
    }

}
