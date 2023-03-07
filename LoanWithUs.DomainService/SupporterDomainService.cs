using LoanWithUs.Domain.UserAggregate;

namespace LoanWithUs.DomainService
{
    public class SupporterDomainService : ISupporterDomainService
    {
        private readonly ISupporterRepository _supporterRepository;

        public SupporterDomainService(ISupporterRepository supporterRepository)
        {
            _supporterRepository = supporterRepository;
        }

        public Task<bool> IsMobileReservedWithOtherSupporter(int currentSupporter,string mobileNumber)
        {
            return _supporterRepository.CheckMobileNo(currentSupporter, mobileNumber);
        }

        public Task<bool> IsNationalReservedWithOtherSupporter(int currentSupporter, string mobileNumber)
        {
            return _supporterRepository.CheckNationalCode(currentSupporter, mobileNumber);
        }
    }
}
