using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.Common
{
    public interface IDateTimeServiceProvider
    {
        DateTime GetDate();
    }
    public class DateTimeServiceProvider : IDateTimeServiceProvider
    {
        public DateTime GetDate()
        {
            return DateTime.Now;
        }
    }
}
