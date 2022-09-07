namespace LoanWithUs.Common
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}