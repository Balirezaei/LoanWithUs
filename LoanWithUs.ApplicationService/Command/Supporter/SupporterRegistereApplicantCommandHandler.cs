using LoanWithUs.ApplicationService.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.ApplicationService.Command.Supporter
{
    public class SupporterRegistereApplicantCommandHandler : IRequestHandler<SupporterRegistereApplicantCommand, SupporterRegistereApplicantCammandResult>
    {
        public Task<SupporterRegistereApplicantCammandResult> Handle(SupporterRegistereApplicantCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
