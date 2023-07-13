using LoanWithUs.Common;
using LoanWithUs.Domain;
using LoanWithUs.Persistense.EF.ContextContainer;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LoanWithUs.Persistense.EF.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BasicInfo
    {
        private readonly LoanWithUsContext _context;

        public GenericRepository(LoanWithUsContext context)
        {
            _context = context;
        }
        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public Task<T> Find(long id)
        {
            return _context.Set<T>().FirstOrDefaultAsync(m => m.Id == id);
        }
        //ToDo: Remove this and read from read model
        public IQueryable<T> GetByPredicate(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }
    }
}
