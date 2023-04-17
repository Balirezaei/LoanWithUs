
using MediatR;

namespace LoanWithUs.ApplicationService.Contract.Administrator
{
    public class AdminRegisteredSupporterContract : PagingContract, IRequest<List<AdminRegisteredSupporterDto>>
    {

    }

    public class ApplicantVerificationCommand: IRequest<ApplicantVerificationCommandResult>
    {
        public int ApplicantId { get; set; }
        public int AdminId { get; set; }
    }
    
    public class ApplicantVerificationCommandResult
    {

    }

}
