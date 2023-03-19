namespace LoanWithUs.Domain
{
    /// <summary>
    ///  مدارک مورد نیاز 
    ///  بابت وام های بالای یک مقدار مشخص
    /// </summary>
    public class LoanLadderFrameRequiredDocument
    {
        public int Id { get; private set; }
        public string Title { get; private set; }

        public LoanLadderFrameRequiredDocument(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }


}
