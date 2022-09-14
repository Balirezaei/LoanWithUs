namespace LoanWithUs.Domain
{
    /// <summary>
    /// چارچوب وام
    /// </summary>
    public class LoanLadderFrame
    {
        protected LoanLadderFrame() { }
        public int Id { get; private set; }
        /// <summary>
        /// عنوان
        /// </summary>
        public string Title { get; private set; }
        /// <summary>
        /// مرحله نردبان
        /// </summary>
        public int Step { get; private set; }
        /// <summary>
        /// مبلغ وام
        /// </summary>
        public int Amount { get; private set; }
        /// <summary>
        /// نردبان قبلی مورد نیاز
        /// </summary>
        public LoanLadderFrame? RequiredPreviousLoan { get; private set; }
        public List<LoanLadderInstallmentsCount> AvalableInstallments { get; private set; }

        /// <summary>
        ///  مدارک مورد نیاز، چک یا سفته
        /// </summary>
        public List<LoanLadderFrameRequiredDocument> LoanLadderFrameRequiredDocuments { get; set; }

        public LoanLadderFrame(string title, int step, int amount, LoanLadderFrame? requiredPreviousLoan, List<LoanLadderInstallmentsCount> avalableInstallments)
        {
            Title = title;
            Step = step;
            Amount = amount;
            RequiredPreviousLoan = requiredPreviousLoan;
            AvalableInstallments = avalableInstallments;
        }
    }


}
