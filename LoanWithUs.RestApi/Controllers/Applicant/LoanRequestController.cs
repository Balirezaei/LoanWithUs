using LoanWithUs.Common.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanWithUs.RestApi.Controllers.Applicant
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = LoanRoleNames.Applicant)]
    public class LoanRequestController : ControllerBase
    {

    }
}
