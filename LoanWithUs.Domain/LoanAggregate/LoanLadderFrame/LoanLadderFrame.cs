using LoanWithUs.Common.DefinedType;
using LoanWithUs.Domain.UserAggregate;
using LoanWithUs.Exceptions;

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
        public Amount Amount { get; private set; }

        /// <summary>
        /// نردبان قبلی مورد نیاز
        /// </summary>
        public LoanLadderFrame? RequiredParentLoan { get; private set; }
        public int? RequiredParentLoanId { get; private set; }
        public List<LoanLadderInstallmentsCount> AvalableInstallments { get; private set; }

        /// <summary>
        ///  مدارک مورد نیاز، چک یا سفته
        /// </summary>
        public List<LoanLadderFrameRequiredDocument> LoanLadderFrameRequiredDocuments { get; set; }

        internal LoanLadderFrame(int id, string title, int step, Amount amount, LoanLadderFrame? requiredParentLoan, List<LoanLadderInstallmentsCount> avalableInstallments, ILoanLadderFrameDomainService domainService)
        {
            if (domainService.IsStepRepetitive(step).Result)
            {
                throw new Exception("Repetitive LoanLadderFrame");
            }

            Id = id;
            Title = title;
            Step = step;
            Amount = amount;
            if (requiredParentLoan != null)
            {
                RequiredParentLoanId = requiredParentLoan.Id;
            }
            AvalableInstallments = avalableInstallments;
        }
        public void AppentRequiredDocument(LoanLadderFrameRequiredDocument document)
        {
            LoanLadderFrameRequiredDocuments = LoanLadderFrameRequiredDocuments == null ? new List<LoanLadderFrameRequiredDocument>() : LoanLadderFrameRequiredDocuments;

            LoanLadderFrameRequiredDocuments.Add(document);
        }

        public void InsertInstallment(int installmentCount)
        {
            if (AvalableInstallments == null)
            {
                AvalableInstallments = new List<LoanLadderInstallmentsCount>();
            }
            if (AvalableInstallments.Any(m => m.Count == installmentCount))
            {
                throw new DomainException("این تعداد اقساط قبلن ثبت شده است");
            }
            AvalableInstallments.Add(new LoanLadderInstallmentsCount(installmentCount));
        }
    }

}
