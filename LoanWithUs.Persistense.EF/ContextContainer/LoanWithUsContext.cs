using LoanWithUs.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.Persistense.EF.ContextContainer
{
    public class LoanWithUsContext: DbContext
    {
        public LoanWithUsContext(DbContextOptions<LoanWithUsContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);      
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Applicant> Applicants { get; set; }
    }
}
