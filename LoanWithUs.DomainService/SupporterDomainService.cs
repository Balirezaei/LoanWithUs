using LoanWithUs.Common.DefinedType;
using LoanWithUs.Domain;

namespace LoanWithUs.DomainService
{
    public class SupporterDomainService : ISupporterDomainService
    {
        private readonly ISupporterRepository _supporterRepository;

        public SupporterDomainService(ISupporterRepository supporterRepository)
        {
            _supporterRepository = supporterRepository;
        }

        public Task<bool> IsMobileReservedWithOtherSupporter(int currentSupporter, MobileNumber mobileNumber)
        {
            return _supporterRepository.CheckMobileNumber(currentSupporter, mobileNumber);
        }

        public Task<bool> IsNationalReservedWithOtherSupporter(int currentSupporter, string nationalCode)
        {
            return _supporterRepository.CheckNationalCode(currentSupporter, nationalCode);
        }
    }
}
