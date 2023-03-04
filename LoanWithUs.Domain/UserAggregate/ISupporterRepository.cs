namespace LoanWithUs.Domain.UserAggregate
{
    public interface ISupporterRepository
    {
        IQueryable<Supporter> GetAllSupporter();
        void Add(Supporter supporter);
    }
}