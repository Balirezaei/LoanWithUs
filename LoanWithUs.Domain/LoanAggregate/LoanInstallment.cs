using LoanWithUs.Common;

namespace LoanWithUs.Domain
{
    /// <summary>
    /// اقساط وام
    /// </summary>
    public class LoanInstallment
    {
        protected LoanInstallment()
        {

        }

        public int Amount { get; private set; }

        public LoanInstallment(int amount, int step, DateTime startDate, DateTime endDate)
        {
            Amount = amount;
            Step = step;
            StartDate = startDate;
            EndDate = endDate;
            UniqueIdentity = Guid.NewGuid();
        }
        public int Id { get; private set; }
        public int Step { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public DateTime? PaiedDate { get; private set; }
        public int PenaltyDay { get; private set; }
        public int PenaltyFee { get; private set; }
        public Guid UniqueIdentity { get; private set; }

        //TODO:....
        public void PaidByApplicant(IDateTimeServiceProvider dateProvider)
        {
            PaiedDate = dateProvider.GetDate();
            //توسط دامین ایونت بعد از پرداخت موفق از زرین پال تایید میشود
            if (dateProvider.GetDate() > EndDate)
            {
                //TODO: مکانیزمی بابت جریمه کاربران در نظر گرفته شود
                PenaltyDay = (EndDate - dateProvider.GetDate().Date).Days;
            }
        }
    }
}
