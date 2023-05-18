namespace LoanWithUs.ApplicationService.Contract
{
    public class ActiveApplicantLoan 
    {
        public int LoanId { get; set; }
        public int SerialNumber { get; private set; }
        public string Amount { get; set; }
        public string SupporterFullName { get; set; }
        public string StartDate { get; set; }
        public FileDto ReceiptFile { get; set; }
        public string WageAmount { get; set; }
        public string TotalAmount { get; set; }
        public List<ApplicantLoanRequestInstallmentDto> Installments { get; set; }
        public bool CanBeSettled { get; set; }
    }

}