using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{
    public class RegisteredApplicantCountContract: IRequest<TotalGrid>
    {
        public int SupporterId { get; set; }
    }
}
