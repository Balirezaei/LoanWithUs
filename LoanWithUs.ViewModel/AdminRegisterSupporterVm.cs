using LoanWithUs.Common.DefinedType;

namespace LoanWithUs.ViewModel
{
    public class AdminRegisterSupporterVm
    {
        public string NationalCode { get; set; }
        public MobileNumber MobileNumber { get; set; }
    }

    public class AdminRegisteredSupporterVm: PagingContractVm
    {

    }

    public class PagingContractVm
    {

        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string Sort { get; set; }
        public string Order { get; set; }

    }
}