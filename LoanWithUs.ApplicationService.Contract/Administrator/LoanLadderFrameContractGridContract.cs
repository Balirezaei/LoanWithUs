using LoanWithUs.Common.DefinedType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.ApplicationService.Contract.Administrator
{
    public class LoanLadderFrameContractGridContract : PagingContract, IRequest<List<LoanLadderFrameDto>>
    {

    }
    public class LoanLadderFrameDto
    {
        public string Title { get; set; }

        public int Step { get; set; }

        public Amount Amount { get; set; }
    }


    public class LoanLadderFrameCreateCommand : IRequest<LoanLadderFrameCreateCommandResult>
    {
        public string Title { get; set; }

        public int Step { get; set; }

        public Amount Amount { get; set; }
        public LoanLadderFrameInstallmentCountDto[] InstallmentCouts { get; set; }
    }

    public class LoanLadderFrameInstallmentCountDto
    {
        public LoanLadderFrameInstallmentCountDto(int count)
        {
            Count = count;
        }

        public int Count { get; private set; }
    }

    public class LoanLadderFrameCreateCommandResult
    {
        public int Id { get; set; }
    }

    public class LoanLadderFrameAppendInstallmentCommand : IRequest
    {
        public int InstallmentCount { get; set; }
        public int LoanLadderFrameId { get; set; }
    }

}
