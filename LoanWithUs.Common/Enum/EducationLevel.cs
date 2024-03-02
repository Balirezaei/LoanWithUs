using System.ComponentModel.DataAnnotations;

namespace LoanWithUs.Common
{
    public enum EducationLevel
    {
        [Display(Name= "دکترا")]
        Doctorate,
        [Display(Name = "کارشناسی ارشد یا فوق لیسانس")]
        Master,
        [Display(Name = "کارشناسی یا لیسانس")]
        Bachelor,
        [Display(Name = "فوق دیپلم یا کاردانی")]
        AdvancedDiploma,
        [Display(Name = "دوره ی متوسطه دوم یا دیپلم")]
        Diploma,
        [Display(Name = "دوره ی متوسطه اول یا سیکل")]
        FirstHighSchool,

    }
}
