using LoanWithUs.Domain;
using LoanWithUs.Persistense.EF.ContextContainer;
using Microsoft.EntityFrameworkCore;

namespace LoanWithUs.Persistense.EF.Repository
{
    public class FileRepository : IFileRepository
    {
        private readonly LoanWithUsContext _context;

        public FileRepository(LoanWithUsContext context)
        {
            _context = context;
        }

        public async Task Create(LoanWithUsFile file)
        {
            _ = _context.LoanWithUsFiles.AddAsync(file);
        }

        public void Delete(LoanWithUsFile file)
        {
            _context.LoanWithUsFiles.Remove(file);
        }

        public Task<LoanWithUsFile> Find(int id)
        {
            return _context.LoanWithUsFiles.SingleOrDefaultAsync(m => m.Id == id);
        }
    }
}
