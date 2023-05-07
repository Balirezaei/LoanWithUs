using LoanWithUs.Common.DefinedType;
using LoanWithUs.Common.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.ApplicationService.Contract.Applicant
{
    public class ApplicantRequestLoanCommand : IRequest<ApplicantRequestLoanResult>
    {
        public int ApplicantId { get; set; }
        public string Reason { get; set; }
        public Amount Amount { get; set; }
        public int LoanLadderInstallmentsCount { get; set; }
    }

    public class ApplicantRequestLoanResult
    {
        public int LoanRequestId { get; set; }
        public string TrackingNumber { get; set; }
        public ApplicantLoanRequestState State { get; set; }
    }

    public class DeactiveLoanRequest : IRequest
    {
        public int ApplicantId { get; set; }
    }
}
