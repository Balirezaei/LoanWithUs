using LoanWithUs.Common.DefinedType;
using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{
    public class ValidateUserOtpQuery :UserDataSecurityDate, IRequest<ValidateOtpQueryResult>
    {
        public ValidateUserOtpQuery(MobileNumber mobileNumber, string code)
        {
            MobileNumber = mobileNumber;
            this.code = code;
        }

        public MobileNumber MobileNumber { get; set; }
        public string code { get; set; }
    }
}