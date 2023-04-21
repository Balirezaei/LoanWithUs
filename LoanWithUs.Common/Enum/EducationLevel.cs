using System.ComponentModel.DataAnnotations;

namespace LoanWithUs.Common
{
    public enum EducationLevel
    {
        [Display(Name= "دکترا")]
        Doctorate=1,
        [Display(Name = "کارشناسی ارشد یا فوق لیسانس")]
        Master =2,
        [Display(Name = "کارشناسی یا لیسانس")]
        Bachelor =3,
        [Display(Name = "فوق دیپلم یا کاردانی")]
        AdvancedDiploma=4,
        [Display(Name = "دوره ی متوسطه دوم یا دیپلم")]
        diploma = 5,
        [Display(Name = "دوره ی متوسطه اول یا سیکل")]
        FirstHighSchool =6,

    }
}
