namespace LoanWithUs.Domain.UserAggregate
{
    public interface IApplicantDomainService
    {
        Task<bool> MobileAvailabilityWithOtherUserType(string mobileNumber);
    }

}