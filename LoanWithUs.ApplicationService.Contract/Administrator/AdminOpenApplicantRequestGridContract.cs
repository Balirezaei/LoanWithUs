using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{
    public class AdminOpenApplicantRequestGridContract : PagingContract, IRequest<List<AdminApplicantRequestGrid>>
    {

    }

   
}