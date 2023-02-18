using Newtonsoft.Json;
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
        public static string LoanTrim(this string input)
        {
            return input.Trim().ToLower();
        }
        //public static TokenInfo GetTokenInfoFromJWT(this string jwt)
        //{
        //    return DecodeToken(jwt);
        //}

        //private static TokenInfo DecodeToken(string token)
        //{
        //    try
        //    {
        //        byte[] data = ConvertFromBase64String(token.Split('.')[1]);
        //        string decodedString = Encoding.UTF8.GetString(data);
        //        return JsonConvert.DeserializeObject<TokenInfo>(decodedString);
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //}


        //private static byte[] ConvertFromBase64String(string input)
        //{
        //    if (String.IsNullOrWhiteSpace(input)) return null;
        //    try
        //    {
        //        string working = input.Replace('-', '+').Replace('_', '/'); ;
        //        while (working.Length % 4 != 0)
        //        {
        //            working += '=';
        //        }
        //        return Convert.FromBase64String(working);
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}
    }
}
