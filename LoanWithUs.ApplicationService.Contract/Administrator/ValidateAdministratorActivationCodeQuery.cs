using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{

    public class ValidateAdministratorOTPQuery : UserDataSecurityِate, IRequest<AdministratorOTPValidationResult>
    {
        public ValidateAdministratorOTPQuery(Guid key, string code)
        {
            this.key = key;
            this.code = code;
        }

        public Guid key { get; set; }
        public string code { get; set; }
    }
    public class AdministratorOTPValidationResult : ValidateOtpQueryResult
    {
        public AdministratorOTPValidationResult(bool isValid) : base(isValid)
        {
        }
        public int UserId { get; set; }
        public string FullName { get; set; }
    }


}