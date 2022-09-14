using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.Domain.UserAggregate
{
    public interface IApplicantRepository
    {
        Task CreateApplicant(Applicant applicant);
    }

    public interface IApplicantReadRepository
    {
        Task<bool> CheckUserActivationCode(string mobile, string code);
        Task<bool> CheckUserMobileAvailibilityWithAllUserType(string mobile);
        Task<Applicant> FindApplicantByMobile(string mobile);
    }

}
