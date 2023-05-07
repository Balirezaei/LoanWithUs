namespace LoanWithUs.ApplicationService.Contract
{
    public class RequestOtpResult
    {
        public Guid key { get; set; }

        public RequestOtpResult(Guid key)
        {
            this.key = key;
        }
    }

}