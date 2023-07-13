using LoanWithUs.Common;
using System.Linq.Expressions;

namespace LoanWithUs.Domain
{
    public interface IGenericRepository<T> where T : BasicInfo
    {
        Task Add(T entity);
        void Update(T entity);

        void Delete(T entity);


        Task<T> Find(long id);

        IQueryable<T> GetByPredicate(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();



    }
}
