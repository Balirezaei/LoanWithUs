using LoanWithUs.Common.DefinedType;

namespace LoanWithUs.Domain
{
    public interface ISupporterDomainService
    {
        Task<bool> IsMobileReservedWithOtherSupporter(int currentSupporter, MobileNumber mobileNumber);
        Task<bool> IsNationalReservedWithOtherSupporter(int currentSupporter, string nationalCode);
    }
}