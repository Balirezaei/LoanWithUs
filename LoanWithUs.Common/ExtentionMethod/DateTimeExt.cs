using System.Globalization;

namespace LoanWithUs.Common.ExtentionMethod
{
    public static class DateTimeExt
    {
        public static DateTime S2M(this String convDate)
        {
            DateTime returnValue;
            var jc = new PersianCalendar();

            if (convDate.Length == 8 & convDate.Contains("/") && !convDate.StartsWith("13"))
                convDate = "13" + convDate;
            if (convDate.Length < 8)
            {
                returnValue = DateTime.Parse("1900/01/01 12:00:00 AM");
                return returnValue;
            }

            try
            {
                returnValue = jc.ToDateTime(int.Parse(convDate.Substring(0, 4)),
                                            int.Parse(convDate.Substring(5, 2)),
                                            int.Parse(convDate.Substring(8, 2)), 1, 1, 1, 1);
            }
            catch
            {
                var dt1 = jc.ToDateTime(int.Parse(convDate.Split('/')[0]), int.Parse(convDate.Split('/')[1])
                    , int.Parse(convDate.Split('/')[2]), 0, 0, 0, 0);

                returnValue = dt1;
            }
            return returnValue;
        }
        //1395/09/27  00:10:35
        public static DateTime S2MWithTime(this String convDate)
        {
            DateTime returnValue;
            var jc = new PersianCalendar();

            if (convDate.Length == 8 & convDate.Contains("/") && !convDate.StartsWith("13"))
                convDate = "13" + convDate;
            if (convDate.Length < 8)
            {
                returnValue = DateTime.Parse("1900/01/01 12:00:00 AM");
                return returnValue;
            }

            try
            {
                returnValue = jc.ToDateTime(int.Parse(convDate.Substring(0, 4)),
                                            int.Parse(convDate.Substring(5, 2)),
                                            int.Parse(convDate.Substring(8, 2)),
                                            int.Parse(convDate.Substring(12, 2)),
                                            int.Parse(convDate.Substring(15, 2)),
                                            int.Parse(convDate.Substring(18, 2)), 1);
            }
            catch (Exception ex)
            {
                var dt1 = jc.ToDateTime(int.Parse(convDate.Split('/')[0]), int.Parse(convDate.Split('/')[1])
                    , int.Parse(convDate.Split('/')[2]), 0, 0, 0, 0);

                returnValue = dt1;
            }
            return returnValue;
        }


        public static String M2S(this DateTime convDate)
        {
            var jc = new PersianCalendar();
            if (convDate.ToString(CultureInfo.InvariantCulture) == "12:00:00 AM")
            {
                return "1300/01/01";
            }
            try
            {
                var farsiMinute = Convert.ToString(jc.GetMinute(convDate));
                var farsiHour = Convert.ToString(jc.GetHour(convDate));
                var farsiYear = Convert.ToString(jc.GetYear(convDate));
                var farsiMonth = Convert.ToString(jc.GetMonth(convDate));
                var farsiDay = Convert.ToString(jc.GetDayOfMonth(convDate));
                farsiDay = farsiDay.PadLeft(2, '0');
                farsiMonth = farsiMonth.PadLeft(2, '0');
                var returnValue = farsiYear + "/" + farsiMonth + "/" + farsiDay + " " + farsiHour.PadLeft(2, '0') + ":" + farsiMinute.PadLeft(2, '0');
                return returnValue;
            }
            catch
            {
                return "1300/01/01";
            }
        }
    }
}
