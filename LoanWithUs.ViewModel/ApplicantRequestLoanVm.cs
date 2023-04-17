using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.ViewModel
{
    public class ApplicantRequestLoanVm
    {
        public string Reason { get; set; }
        public int Amount { get; set; }
        public int LoanLadderInstallmentsCount { get; set; }
    }
}
