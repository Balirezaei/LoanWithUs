namespace LoanWithUs.ApplicationService.Contract
{
    public class ValidateUserActivationCodeQueryResult
    {
        public bool IsValid { get; set; }

        public ValidateUserActivationCodeQueryResult(bool isValid)
        {
            IsValid = isValid;
        }
    }
}