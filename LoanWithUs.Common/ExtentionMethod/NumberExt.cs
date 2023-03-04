using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.Common.ExtentionMethod
{
    public static class NumberExt
    {
        public static bool IsNullORZero(this int val)
        {
            return val == 0;
        }
    }
}
