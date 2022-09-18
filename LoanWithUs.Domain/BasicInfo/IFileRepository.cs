namespace LoanWithUs.Domain.BasicInfo
{
    public interface IFileRepository
    {
        Task<LoanWithUsFile> Find(int id);
        Task Create(LoanWithUsFile file);
        void Delete(LoanWithUsFile file);
    }
}