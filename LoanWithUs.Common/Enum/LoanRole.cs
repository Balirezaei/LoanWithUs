using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.Common.Enum
{
    public enum LoanRole
    {
        Admin,
        Supporter,
        Applicant
    }
    public static class LoanRoleNames
    {
        public const string Admin = "Admin";
        public const string Supporter = "Supporter";
        public const string Applicant = "Applicant";
    }

}
