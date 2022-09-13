using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.Common.ExtentionMethod
{
    public static class StringExt
    {
        public static string RecheckMobileNumber(this string mobile)
        {
            mobile = mobile.Replace("+98", "");

            return mobile.StartsWith("9") ? "0" + mobile : mobile;
        }
    }
}
