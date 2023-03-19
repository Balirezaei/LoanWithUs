using System.Web;

namespace LoanWithUs.IntegrationTest
{
    public static class ExMethod
    {
        public static string ToQueryString(this object obj)
        {

            var properties = from p in obj.GetType().GetProperties()
                             where p.GetValue(obj, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());

            return String.Join("&", properties.ToArray());
        }
    }
    //public class ToMemoryTesting : ToTesting
    //{

    //    protected ToMemoryTesting(TestUserLogined currentUser):base("ToMemory", currentUser)
    //    {
          
    //    }

    //}
}