namespace LoanWithUs.Domain
{
    /// <summary>
    ///  تعداد اقساط
    ///  شش ماهه /شش قسط
    ///  دوازده ماهه/ دوازده قسط
    ///  هجده ماهه/ هجده قسط
    ///  بیست و چهار ماهه /بیست و چهار قسط
    /// </summary>
    public class LoanLadderInstallmentsCount
    {
        protected LoanLadderInstallmentsCount()
        {
        }
        public LoanLadderInstallmentsCount(int count)
        {
            Count = count;
        }
        public int Id { get; set; }
        public int Count { get; private set; }

    }

}
