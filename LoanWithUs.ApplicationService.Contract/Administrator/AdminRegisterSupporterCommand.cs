using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.ApplicationService.Contract.Administrator
{
    public class AdminRegisterSupporterCommand : IRequest<AdminRegisterSupporterCommandResult>
    {
        public string NationalCode { get; set; }
        public string MobileNo { get; set; }
        public int AdminId { get; set; }
    }

    public class AdminRegisterSupporterCommandResult
    {
        public int Id { get; set; }

        public AdminRegisterSupporterCommandResult(int id)
        {
            Id = id;
        }
    }

}
