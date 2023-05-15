using LoanWithUs.Common.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanWithUs.RestApi.Controllers.Supporter
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = LoanRoleNames.Supporter)]
    public class SupportedLoanController : ControllerBase
    {

    }
}
