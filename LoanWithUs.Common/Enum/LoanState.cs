namespace LoanWithUs.Common.Enum
{
    public enum LoanState
    {
        /// <summary>
        /// کاربر درخواست داده
        /// </summary>
        UserRequested,
        /// <summary>
        /// تایید پشتیبان
        /// </summary>
        SupporterConfirmed,
        /// <summary>
        /// تایید ادمین
        /// </summary>
        AdminConfirmed,
        /// <summary>
        /// آماده پرداخت
        /// </summary>
        ReadyToPaied,
        /// <summary>
        /// پرداخت شده 
        /// </summary>
        Paied,
        /// <summary>
        /// درخواست رد شده
        /// </summary>
        Rejected,
        /// <summary>
        /// تسویه شده
        /// </summary>
        settled
    }
}
