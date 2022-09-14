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
        public LoanLadderInstallmentsCount(int count, string title)
        {
            this.Title = title;
            this.Count = count;
        }
        public int Id { get; private set; }
        public string Title { get; private set; }
        public int Count { get; private set; }

    }






}
