namespace LoanWithUs.ApplicationService.Contract
{
    public class AdminRequestOtpResult: RequestOtpResult
    {
        public int AdminId { get; set; }    

        public AdminRequestOtpResult(Guid key, int adminId) :base(key)
        {
            AdminId = adminId;
        }
    }
}