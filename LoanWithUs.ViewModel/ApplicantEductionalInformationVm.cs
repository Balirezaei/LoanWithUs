using LoanWithUs.Common;

namespace LoanWithUs.ViewModel
{
    public class ApplicantEductionalInformationVm
    {
        public EducationLevel LastEducationLevel { get; set; }
        public string EducationalSubject { get; set; }

    }
    public class ApplicantPersonalInformationVm
    {
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string MotherFullName { get;  set; }
        public string FatherFullName { get;  set; }
        public DateTime BirthDate { get;set; }
        public string IdentityNumber { get;  set; }
        public string Job { get;  set; }
        public bool IsMale { get;  set; }
        public bool IsMarried { get;  set; }
        public int ChildrenCount { get;  set; }
        public int MinimumIncome { get; set; }

    }

    public class ApplicantBanckAccountInformationVm
    {
        public string ShabaNumber { get;  set; }
        public string BankCartNumber { get;  set; }
        public BankType BankType { get;  set; }
        public bool IsActive { get; set; }

    }

    public class ApplicantActiveBanckAccountInformationVm
    {
        public string ShabaNumber { get;  set; }
    }
    public class ApplicantRemoveBanckAccountInformationVm
    {
        public string ShabaNumber { get;  set; }
    }
}