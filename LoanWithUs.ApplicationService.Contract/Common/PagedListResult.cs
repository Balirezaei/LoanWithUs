namespace LoanWithUs.ApplicationService.Contract
{
    public class PagedListResult<T> : ListResult<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public int PageCount
        {
            get
            {
                if (this.TotalCount == 0)
                {
                    return 0;
                }
                var t = this.TotalCount / this.PageSize;
                if (t == 0)
                {
                    t = 1;
                }
                return (int)t;
            }
        }

        public long TotalCount { get; set; }
    }

}
