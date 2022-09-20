namespace LoanWithUs.Domain.UserAggregate
{
    public interface IApplicantDomainService
    {
        Task<bool> IsMobileReservedWithOtherUserType(string mobileNumber);
    }

}