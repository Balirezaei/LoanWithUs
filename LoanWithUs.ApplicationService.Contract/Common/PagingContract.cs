using LoanWithUs.Common.ExtentionMethod;


namespace LoanWithUs.ApplicationService.Contract
{
    public class PagingContract
    {

        private int _pageSize;
        private int _pageNumber;

        public int PageSize
        {
            get => _pageSize.IsNullORZero() ? 10 : _pageSize;
            set => _pageSize = value;
        }

        public int PageNumber
        {
            get => _pageNumber.IsNullORZero() ? 1 : _pageNumber;
            set => _pageNumber = value;
        }

        public string Sort { get; set; }
        public string Order { get; set; }

    }
}
