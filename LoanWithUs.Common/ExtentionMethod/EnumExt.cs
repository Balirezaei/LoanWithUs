using LoanWithUs.Common.Enum;
using System.ComponentModel.DataAnnotations;

namespace LoanWithUs.Common.ExtentionMethod
{
    public static class EnumExt
    {
        public static string GetDisplayName(this MoneyType value)
        {

            try
            {
                var fieldInfo = value.GetType().GetField(value.ToString());
                var descriptionAttributes = fieldInfo.GetCustomAttributes(
                    typeof(DisplayAttribute), false) as DisplayAttribute[];
                if (descriptionAttributes == null) return string.Empty;
                return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].Name : value.ToString();
            }
            catch
            {
                return "";
            }

        }
    }
}
