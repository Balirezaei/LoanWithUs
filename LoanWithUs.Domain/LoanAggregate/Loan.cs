﻿using LoanWithUs.Common;
using LoanWithUs.Common.DefinedType;

namespace LoanWithUs.Domain
{
    /// <summary>
    /// درخواست تایید شده و پرداخت شده به وام اصلی تبدیل میشود
    /// </summary>
    public class Loan : AggregateRoot
    {
        protected Loan() { }
        /// <summary>
        /// مبلغ وام
        /// </summary>
        public Amount Amount { get; private set; }
        /// <summary>
        /// درخواستگر وام 
        /// پشتیبان یا درخواستگران
        /// </summary>
        public User Requester { get; private set; }
        public int RequesterId { get; private set; }

        public LoanWithUsFile ReciptFile { get; private set; }


        /// <summary>
        /// تاریخ واریز وام
        /// </summary>
        public DateTime StartDate { get; private set; }
        /// <summary>
        /// آیا وام به طور کامل تسویه شده است؟
        /// </summary>
        public bool IsSettled { get; set; }
        public List<LoanInstallment> LoanInstallments { get; private set; }

        public Loan(Amount amount, Applicant applicant, int installmentCount, IDateTimeServiceProvider dateProvider)
        {
            Amount = amount;
            Requester = applicant;
            StartDate = dateProvider.GetDate();
            this.LoanInstallments = GenerateLoanInstallment(installmentCount,dateProvider).ToList();
        }
      

        private IEnumerable<LoanInstallment> GenerateLoanInstallment(int installmentCount, IDateTimeServiceProvider dateProvider)
        {
            int count = installmentCount;
            int price = this.Amount.amount;
            if ((price % count) == 0)
            {
                for (int i = 0; i < count; i++)
                {
                    var amount = (price / count);
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
                        amount = remain;
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
        //TODO:....
        public void PaidLastByApplicant(IDateTimeServiceProvider dateProvider)
        {
            var installment = this.LoanInstallments.FirstOrDefault(m => m.PaiedDate == null);
            installment.PaidByApplicant(dateProvider);
            if (this.LoanInstallments.All(m => m.PaiedDate != null))
            {
                LoanSettlement();
            }
        }

        /// <summary>
        /// تسویه حساب وام با توجه به قواعد خاص
        /// </summary>
        public void LoanSettlement()
        {
            //TODO:....
        }

    }
}
