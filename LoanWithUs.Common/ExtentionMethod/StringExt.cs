﻿using System;
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
            return mobile.StartsWith("09") ? "+98" + mobile.Substring(2, mobile.Length - 2) : mobile;
        }
    }
}