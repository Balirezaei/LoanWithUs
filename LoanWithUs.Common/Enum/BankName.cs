using System.ComponentModel.DataAnnotations;

namespace LoanWithUs.Common
{
    public enum BankType
    {
        [Display(Name = "ملی")]
        Melli = 1,
        [Display(Name = "صادرات")]
        Saderat = 2,
        [Display(Name = "تجارت")]
        Tejarat = 3,
        [Display(Name = "ملت")]
        Mellat = 4,
        [Display(Name = "مسکن")]
        Maskan = 5,
        [Display(Name = "قرض الحسنه رسالت")]
        Resalat = 6,
        [Display(Name = "شهر")]
        Sahr = 7,
        [Display(Name = "سامان")]
        Saman = 8,
        [Display(Name = "آینده")]
        Ayandeh = 9,
        [Display(Name = "پاسارگاد")]
        Pasargad = 10,

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
