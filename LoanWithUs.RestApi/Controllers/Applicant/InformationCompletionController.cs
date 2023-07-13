using AutoMapper;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common.Enum;
using LoanWithUs.Domain;
using LoanWithUs.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace LoanWithUs.RestApi.Controllers.Applicant
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = LoanRoleNames.Applicant)]
    public class InformationCompletionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public InformationCompletionController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ApplicantCompleteInformationCommandResult> UpdateApplicantEducationalInformation(ApplicantEductionalInformationVm vm)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(m => m.Type == ClaimTypes.NameIdentifier).Value;

            var res = await _mediator.Send(new ApplicantCompleteEductionalInformationCommand()
            {
                EducationalSubject = vm.EducationalSubject,
                LastEducationLevel = vm.LastEducationLevel,
                ApplicantId = int.Parse(userId)
            });
            return res;
        }

        [HttpPost]
        public Task<ApplicantCompleteInformationCommandResult> UpdateApplicantPersonalInformation(ApplicantPersonalInformationVm vm)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(m => m.Type == ClaimTypes.NameIdentifier).Value;
            var cmd = _mapper.Map<ApplicantPersonalInformationCommand>(vm);
            cmd.ApplicantId = int.Parse(userId);
            return _mediator.Send(cmd);
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

        [HttpPost]
        public Task<ApplicantCompleteInformationCommandResult> AddBanckAccount(ApplicantBanckAccountInformationVm vm)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(m => m.Type == ClaimTypes.NameIdentifier).Value;
            var cmd = _mapper.Map<ApplicantAddBankInformationCommand>(vm);
            cmd.ApplicantId = int.Parse(userId);
            return _mediator.Send(cmd);
        }

        [HttpPost]
        public Task<ApplicantCompleteInformationCommandResult> DeleteBanckAccount(ApplicantRemoveBanckAccountInformationVm vm)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(m => m.Type == ClaimTypes.NameIdentifier).Value;
            var cmd = _mapper.Map<ApplicantRemoveBankAccountCommand>(vm);
            cmd.ApplicantId = int.Parse(userId);
            return _mediator.Send(cmd);
        }
        [HttpPost]
        public Task<ApplicantCompleteInformationCommandResult> ActiveBanckAccount(ApplicantActiveBanckAccountInformationVm vm)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(m => m.Type == ClaimTypes.NameIdentifier).Value;
            var cmd = _mapper.Map<ApplicantActiveCurrentBanckAccountCommand>(vm);
            cmd.ApplicantId = int.Parse(userId);
            return _mediator.Send(cmd);
        }


        [HttpPost]
        public Task<ApplicantCompleteInformationCommandResult> UpdateDocumnets(List<ApplicantDocumentsVm> vm)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(m => m.Type == ClaimTypes.NameIdentifier).Value;
            var cmd = new ApplicantDocumentsUpdateCommand
            {
                ApplicantId = int.Parse(userId),
                FileId = vm.Select(m => m.FileId).ToArray(),
            };
            return _mediator.Send(cmd);
        }

        [HttpGet]
        public Task<List<CityDto>> GetAllProvince()
        {
            return _mediator.Send(new GetCityQuery());
        }

        [HttpGet]
        public Task<List<CityDto>> GetAllCityWithProvince(int provinceId)
        {
            return _mediator.Send(new GetCityQuery() { ParentProvince = provinceId });
        }

        [HttpPost]
        public Task UpdateAddressInformation(ApplicantAddressInformationVm vm)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(m => m.Type == ClaimTypes.NameIdentifier).Value;
            var cmd = _mapper.Map<ApplicantAddressInformationCommand>(vm);
            cmd.ApplicantId = int.Parse(userId);
            return _mediator.Send(cmd);
        }
    }
}
