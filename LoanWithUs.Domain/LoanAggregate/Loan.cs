using LoanWithUs.Common;
using LoanWithUs.Common.DefinedType;
using LoanWithUs.Exceptions;

namespace LoanWithUs.Domain
{
    /// <summary>
    /// درخواست تایید شده و پرداخت شده به وام اصلی تبدیل میشود
    /// </summary>
    public class Loan : AggregateRoot
    {
        protected Loan() { }

        public int Id { get; private set; }

        /// <summary>
        /// مبلغ وام
        /// </summary>
        public Amount Amount { get; private set; }
        /// <summary>
        /// درخواستگر وام 
        /// پشتیبان یا درخواستگران
        /// </summary>
        public virtual User Requester { get; private set; }
        public int RequesterId { get; private set; }

        public virtual LoanWithUsFile ReciptFile { get; private set; }
        public int SerialNumber { get; private set; }

        public int DailyPenalty { get; private set; }

        /// <summary>
        /// تاریخ واریز وام
        /// </summary>
        public DateTime StartDate { get; private set; }
        /// <summary>
        /// آیا وام به طور کامل تسویه شده است؟
        /// </summary>
        public bool IsSettled { get; set; }
        public virtual List<LoanInstallment> LoanInstallments { get; private set; }
        public virtual List<LoanRequiredDocument> LoanRequiredDocuments { get; set; }
        public float LoanWage { get; private set; }

        internal Loan(ApplicantLoanRequest loanRequest, LoanWithUsFile ReciptFile,float loanWage, IDateTimeServiceProvider dateProvider)
        {
            if (loanRequest.LastState!=Common.Enum.ApplicantLoanRequestState.Paied)
            {
                throw new DomainException("عملیات غیر مجاز");
            }
            RequesterId = loanRequest.ApplicantId;
            Amount = loanRequest.Amount;
            DailyPenalty = Amount.amount / 1000;
            Requester = loanRequest.Applicant;
            StartDate = dateProvider.GetDate();
            this.ReciptFile = ReciptFile;
            this.LoanWage = loanWage;
            if (this.LoanRequiredDocuments == null)
            {
                this.LoanRequiredDocuments = new List<LoanRequiredDocument>();
            }
            this.LoanRequiredDocuments = new List<LoanRequiredDocument>()
            {
                new LoanRequiredDocument(LoanRequiredDocumentType.Supporter,new SupporterUserType("Supporter","پشتیبان",loanRequest.Supporter.DisplayName()),null)
            };

            this.LoanInstallments = GenerateLoanInstallment(loanRequest.InstallmentsCount, dateProvider).ToList();
        }

        public List<LoanInstallment> GetLoanInstallmentsWithPenaltyCalculation(IDateTimeServiceProvider dateProvider)
        {
            foreach (var item in LoanInstallments.Where(m => m.PaiedDate == null && (dateProvider.GetDate().Date - m.EndDate.Date).Days > 0))
            {
                item.CalculatePenalty(dateProvider, this.DailyPenalty);
            }
            return this.LoanInstallments;
        }
        private IEnumerable<LoanInstallment> GenerateLoanInstallment(int installmentCount, IDateTimeServiceProvider dateProvider)
        {
            float wage = this.LoanWage;
            int count = installmentCount;
            int price = this.Amount.amount;
            int lastMonthWage = (int)(price * wage);
            if ((price % count) == 0)
            {
                for (int i = 0; i < count; i++)
                {
                    var amount = (price / count);
                    if (i==(count-1))
                    {
                        amount += lastMonthWage;
                        lastMonthWage = 0;
                    }
                   
                    var startDate = dateProvider.GetDate().AddMonths(i + 1).AddDays(1).Date;
                    var endDate = startDate.AddDays(3).Date.AddHours(23);
                    yield return new LoanInstallment(amount, (i + 1), startDate, endDate);
                }
            }
            else
            {
                var installment = ((decimal)price / count);
                var amount = (int)Math.Floor(installment);
                for (int i = 0; i < count; i++)
                {
                    if (i == count - 1)
                    {
                        var remain = price - (amount * (i));
                        amount = remain + lastMonthWage;
                        lastMonthWage = 0;
                    }
                   
                    var startDate = dateProvider.GetDate().AddMonths(i + 1).AddDays(1).Date;
                    var endDate = startDate.AddDays(3).Date.AddHours(23);
                    yield return new LoanInstallment(amount, (i + 1), startDate, endDate);
                }

            }
        }


        /// <summary>
        /// پرداخت آخرین 
        /// </summary>
        public void PaidInstallmentByApplicant(Guid uniqueIdentityy, IApplicantDomainService domainService, IDateTimeServiceProvider dateProvider)
        {
            var installment = this.LoanInstallments.FirstOrDefault(m => m.PaiedDate == null && m.UniqueIdentity == uniqueIdentityy);
            installment.PaidByApplicant(dateProvider);
            /// <summary>
            /// تسویه حساب وام 
            /// </summary>
            if (this.LoanInstallments.All(m => m.PaiedDate != null))
            {
                this.IsSettled = true;
                if (this.Requester.GetType().Name == "Applicant")
                {
                    ((Applicant)this.Requester).MoveToNextLadderAfterLoanSettel(domainService, dateProvider);
                }
            }
        }

      
        

    }
    public class SupporterUserType
    {
        public SupporterUserType(string userType, string userTypeTitle, string userFullName)
        {
            UserType = userType;
            UserTypeTitle = userTypeTitle;
            UserFullName = userFullName;
        }

        public string UserType { get; set; }
        public string UserTypeTitle { get; set; }
        public string UserFullName { get; set; }

    }
    public class LoanRequiredDocument
    {
        public LoanRequiredDocumentType Type { get; set; }
        public SupporterUserType Description { get; set; }

        public virtual LoanWithUsFile? File { get; private set; }
        public int? LoanWithUsFileId { get; set; }

        internal LoanRequiredDocument(LoanRequiredDocumentType type, SupporterUserType description, LoanWithUsFile file)
        {
            Type = type;
            Description = description;
            File = file;
        }

        protected LoanRequiredDocument()
        {
        }

    }


}
