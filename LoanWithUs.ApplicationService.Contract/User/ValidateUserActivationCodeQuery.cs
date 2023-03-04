using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{
    public class ValidateUserOtpQuery :UserDataSecurityDate, IRequest<ValidateOtpQueryResult>
    {
        public ValidateUserOtpQuery(string mobile, string code)
        {
            Mobile = mobile;
            this.code = code;
        }

        public string Mobile { get; set; }
        public string code { get; set; }
    }
}