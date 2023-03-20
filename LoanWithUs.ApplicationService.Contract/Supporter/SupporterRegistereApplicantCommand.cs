using LoanWithUs.Common.DefinedType;
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
        public MobileNumber MobileNumber { get; set; }
        public string NationalCode { get; set; }
        public int SupporterId { get; set; }
    }
    public class RegisteredApplicantGridContract : PagingContract, IRequest<List<RegisteredApplicantDto>>
    {
        public int SupporterId { get; set; }
    }
    public class RegisteredApplicantDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string MobileNumber { get; set; }
        public string NationalCode { get; set; }
    }
}
