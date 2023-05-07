using LoanWithUs.Domain;
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
            modelBuilder.HasSequence<int>("Sequence-TrackingNumber").IncrementsBy(1).StartsAt(1000);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);      
            base.OnModelCreating(modelBuilder);
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Applicant> Applicants { get; set; }

        public DbSet<Supporter> Supporters { get; set; }

        public DbSet<LoanWithUsFile> LoanWithUsFiles { get; set; }
        public DbSet<City> Cities { get; set; }

        public DbSet<Administrator> Administrators { get; set; }

        public DbSet<LoanLadderFrame> LoanLadderFrames { get; set; }
        public DbSet<ApplicantLoanRequest> ApplicantLoanRequests { get; set; }

        public DbSet<Loan> Loans { get; set; }
    }
}
