using LoanWithUs.Common.ExtentionMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.ApplicationService.Contract
{
    public class PagingContract
    {
        public PagingContract()
        {

        }

        public PagingContract(int pageSize, int pageNumber, string sort, string order)
        {
            PageSize = pageSize.IsNullORZero() ? 10 : pageSize;
            PageNumber = pageNumber.IsNullORZero() ? 1 : pageSize;
            Sort = sort;
            Order = order;
        }

        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string Sort { get; set; }
        public string Order { get; set; }

    }
}
