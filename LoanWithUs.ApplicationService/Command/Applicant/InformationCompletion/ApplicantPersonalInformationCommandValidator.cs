using FluentValidation;
using LoanWithUs.ApplicationService.Contract;

namespace LoanWithUs.ApplicationService.Command
{
    public class ApplicantPersonalInformationCommandValidator : AbstractValidator<ApplicantPersonalInformationCommand>
    {
        public ApplicantPersonalInformationCommandValidator()
        {
            RuleFor(p => p).Cascade(CascadeMode.StopOnFirstFailure)
               .Must(p => !string.IsNullOrWhiteSpace(p.FirstName)).WithMessage("ورود نام اجباری است.")
               .Must(p => !string.IsNullOrWhiteSpace(p.LastName)).WithMessage("ورود نام خانوادگی اجباری است.")
               .Must(p => !string.IsNullOrWhiteSpace(p.FatherFullName)).WithMessage("ورود نام پدر اجباری است.")
               .Must(p => !string.IsNullOrWhiteSpace(p.MotherFullName)).WithMessage("ورود نام مادر اجباری است.")
               .Must(p => !string.IsNullOrWhiteSpace(p.Job)).WithMessage("ورود عنوان شغل اجباری است.")
               .Must(p => !string.IsNullOrWhiteSpace(p.IdentityNumber)).WithMessage("ورود شماره شناسنامه اجباری است.")
               .Must(p => p.MinimumIncome != null && p.MinimumIncome != 0).WithMessage("ورود میزان حداقل درآمد اجباری است.")

               ;
        }
    }

}