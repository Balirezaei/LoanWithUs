using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{
    public class ApplicantInstallmentPaymentCommand : IRequest<ApplicantPaymentResult>
    {
        public Guid UniqueIdentity { get; set; }
        public int ApplicantId { get; set; }

    }

}