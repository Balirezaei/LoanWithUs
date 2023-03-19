using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common.Enum;
using LoanWithUs.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanWithUs.RestApi.Controllers.Applicant
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = LoanRoleNames.Applicant)]
    public class InformationCompletionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public InformationCompletionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> UpdateApplicantEducationalInformation(ApplicantEductionalInformationVm vm)
        {
            var res = await _mediator.Send(new ApplicantCompleteEductionalInformationCommand()
            {
                EducationalSubject = vm.EducationalSubject,
                LastEducationLevel = vm.LastEducationLevel,
                ApplicantId = vm.UserId
            });
            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetApplicantById(int id)
        {
            var res = await _mediator.Send(new GetApplicantByIdQuery()
            {
                ApplicantId = id
            });
            return Ok(res);
        }

    }
}
