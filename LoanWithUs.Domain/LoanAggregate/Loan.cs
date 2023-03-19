using LoanWithUs.Common;
using LoanWithUs.Common.DefinedType;
using LoanWithUs.Domain.LoanAggregate;
using LoanWithUs.Domain.UserAggregate;

namespace LoanWithUs.Domain
{
    /// <summary>
    /// درخواست تایید شده و پرداخت شده به وام اصلی تبدیل میشود
    /// </summary>
    public class Loan : AggregateRoot
    {
        /// <summary>
        /// مبلغ وام
        /// </summary>
        public Amount Amount { get;private set; }
        /// <summary>
        /// درخواستگر وام 
        /// پشتیبان یا درخواستگران
        /// </summary>
        public User LoanRequester { get; private set; }
        /// <summary>
        /// تاریخ واریز وام
        /// </summary>
        public DateTime StartDate { get; private set; }
        /// <summary>
        /// آیا وام به طور کامل تسویه شده است؟
        /// </summary>
        public bool IsSettled { get; set; }
        public List<LoanInstallment> LoanInstallments { get; private set; }
        public  Loan(Amount amount, User loanRequester,int installmentCount)
        {
            Amount = amount;
            LoanRequester = loanRequester;
            StartDate = DateTime.Now;
            this.LoanInstallments = GenerateLoanInstallment(installmentCount).ToList();
        } 


        private IEnumerable<LoanInstallment> GenerateLoanInstallment(int installmentCount)
        {
            int count = installmentCount;
            int price = this.Amount.amount;
            if ((price%count) == 0)
            {
                for (int i = 0; i < count; i++)
                {
                    var amount = (price / count);
                    var startDate = DateTime.Now.AddMonths(i + 1).AddDays(1).Date;
                    var endDate = startDate.AddDays(3).Date.AddHours(23);
                    yield return new LoanInstallment(amount,(i+1), startDate, endDate);
                }
            }
            else
            {
                var installment = ((decimal)price / count);
                var amount = (int)Math.Floor(installment);
                for (int i = 0; i < count; i++)
                {
                    if (i==count-1)
                    {
                        var remain = price - (amount * (i));
                        amount = remain;
                    }
                    var startDate = DateTime.Now.AddMonths(i + 1).AddDays(1).Date;
                    var endDate = startDate.AddDays(3).Date.AddHours(23);
                    yield return new LoanInstallment(amount, (i + 1), startDate, endDate);
                }

            }
        }

        /// <summary>
        /// پرداخت آخرین 
        /// </summary>
        //TODO:....
        public void PaidLastByApplicant()
        {
            var installment=this.LoanInstallments.FirstOrDefault(m => m.PaiedDate == null);
            installment.PaidByApplicant();
            if(this.LoanInstallments.All(m => m.PaiedDate != null))
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
