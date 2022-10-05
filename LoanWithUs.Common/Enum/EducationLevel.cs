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

        //        {text:"دکترا",value:"1"},
        //{text:"کارشناسی ارشد یا فوق لیسانس",value:"2"},
        //{ text: "کارشناسی یا لیسانس",value: "3"},
        //{ text: "فوق دیپلم یا کاردانی",value: "4"},
        //{ text: "دوره ی متوسطه دوم یا دیپلم",value: "5"},
        //{ text: "دوره ی متوسطه اول یا سیکل",value: "6"},

        //Doctorate
        //   Master's or master's degree
        //    Bachelor's or Bachelor's degree
        //     Master's degree or associate's degree
        //   Second high school or diploma
        //  First high school period or cycle
    }
}
