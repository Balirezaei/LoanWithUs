using FluentValidation;
using LoanWithUs.ApplicationService.Contract;

namespace LoanWithUs.ApplicationService.Command
{
    public class ApplicantCompleteEductionalInformationCommandValidator : AbstractValidator<ApplicantCompleteEductionalInformationCommand>
    {
        public ApplicantCompleteEductionalInformationCommandValidator()
        {
            RuleFor(v => v.LastEducationTitle)
                .NotEmpty().WithMessage("ورود عنوان آخرین مدرک تحصیلی اجباریست.");

            RuleFor(v => v.EducationalSubject)
            .NotEmpty().WithMessage("ورود عنوان آخرین رشته تحصیلی اجباریست.");
        }
    }
}