using LoanWithUs.Common.DefinedType;

namespace LoanWithUs.ViewModel
{
    public class AdminRegisterSupporterVm
    {
        public string NationalCode { get; set; }
        public string MobileNumber { get; set; }
    }

    public class AdminRegisteredSupporterVm: PagingContractVm
    {

    }
    
    public class LoanLadderFrameContractGridContractVm : PagingContractVm
    {

    }
    public class RegisteredApplicantGridVm : PagingContractVm
    {


    }
    public class ApplicantOpenRequestGridVm : PagingContractVm
    {


    }


    public class PagingContractVm
    {

        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string Sort { get; set; }
        public string Order { get; set; }

    }
    public class SupporterRegistereApplicantVm
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string NationalCode { get; set; }
    }
}