using LoanWithUs.Domain;
using LoanWithUs.Persistense.EF.ContextContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.Persistense.EF.Repository
{
    public class ApplicantRepository : IApplicantRepository
    {
        private readonly LoanWithUsContext _context;

        public ApplicantRepository(LoanWithUsContext context)
        {
            _context = context;
        }

        public async Task CreateApplicant(Applicant applicant)
        {
            _ = _context.Applicants.AddAsync(applicant);
        }

        public void Update(Applicant applicant)
        {
            _context.Applicants.Update(applicant);
        }
    }
}
