using LoanWithUs.Common.DefinedType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.ViewModel
{
    public class ValidateAdministratorViewModel
    {
        public Guid key { get; set; }
        public string code { get; set; }
    }
    public class ValidateAdministratorOTPViewModel
    {
        public Guid key { get; set; }
        public string code { get; set; }
    }
    public class AdminUserGetByUserNameViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }
    public class AdminUserRequestNewOTPCodeForUserViewModel
    {
        public int AdminId { get; set; }
    }
    public class ValidateUserOtpViewModel
    {
        public string MobileNumber { get; set; }
        public string code { get; set; }
    }
    public class RequestNewOTPCodeForUserViewModel
    {
        public string MobileNumber { get; set; }
    }
    public class LoginUserViewModel
    {
        public string MobileNumber { get; set; }
    }
    public class SupporterLoanRequestActionViewModel
    {
        public int RequestId { get; set; }

    }

    public class AdminLoanRequestAcceptViewModel
    {
        public int RequestId { get; set; }

    }

    public class AdminPayLoanRequestViewModel
    {
        public int RequestId { get; set; }
        public int FileId { get; set; }
    }

    public class AdminLoanRequestRejectViewModel
    {
        public int RequestId { get; set; }
        public string Reason { get; set; }

    }
}
