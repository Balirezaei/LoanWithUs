using LoanWithUs.Common;
using LoanWithUs.Persistense.EF.ContextContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.Persistense.EF.UnitOfWork
{
    public class LoanWithUsUnitOfWork: IUnitOfWork
    {
        private readonly LoanWithUsContext _context;

        public LoanWithUsUnitOfWork(LoanWithUsContext context)
        {
            _context = context;
        }

      
        public Task CommitAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
