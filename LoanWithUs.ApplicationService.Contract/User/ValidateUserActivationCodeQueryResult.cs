using LoanWithUs.Common.Enum;

namespace LoanWithUs.ApplicationService.Contract
{
    public class ValidateOtpQueryResult
    {
        public bool IsValid { get; set; }
        public string RoleName { get; set; }
        public int UserId { get; set; }
        //public string FullName { get; set; }

        public ValidateOtpQueryResult(bool isValid, string role,int userId)
        {
            IsValid = isValid;
            UserId = userId;
            RoleName = role;
        }
    }
}