using LoanWithUs.Common.DefinedType;
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
        public static Amount ToToamnAmount(this int val)
        {
            return new Amount(val, Enum.MoneyType.Toman);
        }

        public static string ToStringSplit3Digit(this int n)
        {
            return n.ToString("#,##0");
        }
    }
}
