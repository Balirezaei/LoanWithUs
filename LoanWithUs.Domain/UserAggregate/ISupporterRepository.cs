namespace LoanWithUs.Domain.UserAggregate
{
    public interface ISupporterRepository
    {
        IQueryable<Supporter> GetAllSupporter();
        void Add(Supporter supporter);
        Task<bool> CheckNationalCode(int exceptCurrentUser,string nationalCode);
        Task<bool> CheckMobileNo(int exceptCurrentUser, string mobileNo);
    }
}