using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LoanWithUs.Common
{
    public enum FileType
    {
        [Display(Name = "تصویر فیش واریزی")]
        DepositReceipt,

        [Display(Name = "تصویر صفحه ی اول شناسنامه")]
        UserIdentityCardFirstPage,

        [Display(Name = "تصویر صفحه ی دوم شناسنامه")]
        UserIdentityCardSecondPage,

        [Display(Name = "تصویر کارت ملی")]
        UserNationalCard,

        [Display(Name = "تصویر گواهی نامه")]
        UserDrivingLicence,

        [Display(Name = "فیش حقوقی")]
        UserSalaryReceipt,

        [Display(Name = "تصویر گردش حساب")]
        UserLastBankFlow,

        [Display(Name = "تصویر اجاره نامه، تصویر سند ملکی")]
        UserAddressDocument,
    }
}
