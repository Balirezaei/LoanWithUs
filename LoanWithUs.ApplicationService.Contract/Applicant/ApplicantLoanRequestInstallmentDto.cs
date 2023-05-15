namespace LoanWithUs.ApplicationService.Contract
{

    public class ApplicantLoanRequestInstallmentDto
    {
        public bool IsPaid { get; set; }
        public bool ReadyToPay { get; set; }
        public string Amount { get; set; }
        public int Step { get; set; }
        public string StartDateForPay { get; set; }
        public string EndDateForPay { get; set; }
        public string PaidDate { get; set; }
    }

}