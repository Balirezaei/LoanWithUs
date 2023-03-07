namespace LoanWithUs.Domain.UserAggregate
{
    public interface ISupporterDomainService
    {
        Task<bool> IsMobileReservedWithOtherSupporter(int currentSupporter,string mobileNumber);
        Task<bool> IsNationalReservedWithOtherSupporter(int currentSupporter,string mobileNumber);
    }
}