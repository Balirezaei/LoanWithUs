using LoanWithUs.Common.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoanWithUs.RestApi.Controllers.Supporter
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = LoanRoleNames.Applicant)]
    public class RegisterApplicantController : ControllerBase
    {
        
    }
}