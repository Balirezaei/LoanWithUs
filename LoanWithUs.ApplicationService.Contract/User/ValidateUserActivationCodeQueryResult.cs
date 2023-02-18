namespace LoanWithUs.ApplicationService.Contract
{
    public class ValidateOtpQueryResult
    {
        public bool IsValid { get; set; }

        public ValidateOtpQueryResult(bool isValid)
        {
            IsValid = isValid;
        }
    }
}