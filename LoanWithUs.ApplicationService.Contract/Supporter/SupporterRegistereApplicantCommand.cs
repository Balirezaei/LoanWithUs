using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.ApplicationService.Contract
{
    public class SupporterRegistereApplicantCommand: IRequest<SupporterRegistereApplicantCammandResult>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string NationalCode { get; set; }
    }
}
