namespace LoanWithUs.ApplicationService.Contract
{
    public class ActiveApplicantLoan 
    {
        public string Amount { get; set; }
        public string SupporterFullName { get; set; }
        public string StartDate { get; set; }
        public FileDto ReceiptFile { get; set; }
        public List<ApplicantLoanRequestInstallmentDto> Installments { get; set; }
    }

}