namespace LoanWithUs.Domain.UserAggregate
{
    public interface IApplicantDomainService
    {
        Task<bool> IsMobileReservedWithAllUserType(int currentUser, string mobileNumber);
        Task<bool> IsNationalReservedWithAllUserType(int currentUser, string nationalCode);
    }

}