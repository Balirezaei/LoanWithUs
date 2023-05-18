using LoanWithUs.Domain;
using LoanWithUs.Persistense.EF.ContextContainer;
using Microsoft.EntityFrameworkCore;

namespace LoanWithUs.Persistense.EF.Repository
{
    public class LoanLadderFrameRepository : ILoanLadderFrameRepository
    {
        private readonly LoanWithUsContext _context;

        public LoanLadderFrameRepository(LoanWithUsContext context)
        {
            _context = context;
        }

        public async Task Add(LoanLadderFrame loanLoadderFrame)
        {
           await _context.LoanLadderFrames.AddAsync(loanLoadderFrame);
        }

        public Task<bool> IsLoanLadderStepRepetitive(int step)
        {
            return _context.LoanLadderFrames.AnyAsync(m=>m.Step == step);
        }

        public IQueryable<LoanLadderFrame> GetAllLoanLadder()
        {
            return _context.LoanLadderFrames;
        }

        public Task<LoanLadderFrame> GetFirstStep() => _context.LoanLadderFrames.FirstOrDefaultAsync(m => m.Step == 1);
        public Task<LoanLadderFrame> GetById(int loanFrameLadderId) => _context.LoanLadderFrames.FirstOrDefaultAsync(m => m.Id == loanFrameLadderId);

        public void Update(LoanLadderFrame loanLadderFrame)
        {
            _context.LoanLadderFrames.Update(loanLadderFrame);
        }

        public Task<LoanLadderFrame> GetNextStep(LoanLadderFrame currentladder)
        {
            return _context.LoanLadderFrames.FirstOrDefaultAsync(m => m.Step > currentladder.Step);
        }
    }
}
