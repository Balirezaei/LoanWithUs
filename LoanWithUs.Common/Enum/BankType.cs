using System.ComponentModel.DataAnnotations;

namespace LoanWithUs.Common
{
    public enum BankType
    {
        [Display(Name = "ملی")]
        Melli,
        [Display(Name = "صادرات")]
        Saderat,
        [Display(Name = "تجارت")]
        Tejarat,
        [Display(Name = "ملت")]
        Mellat,
        [Display(Name = "مسکن")]
        Maskan,
        [Display(Name = "قرض الحسنه رسالت")]
        Resalat,
        [Display(Name = "شهر")]
        Sahr,
        [Display(Name = "سامان")]
        Saman,
        [Display(Name = "آینده")]
        Ayandeh,
        [Display(Name = "پاسارگاد")]
        Pasargad,

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
