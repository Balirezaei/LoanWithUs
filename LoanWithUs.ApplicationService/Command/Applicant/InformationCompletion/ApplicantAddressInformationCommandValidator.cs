using FluentValidation;
using LoanWithUs.ApplicationService.Contract;

namespace LoanWithUs.ApplicationService.Command
{
    public class ApplicantAddressInformationCommandValidator : AbstractValidator<ApplicantAddressInformationCommand>
    {
        public ApplicantAddressInformationCommandValidator()
        {
            RuleFor(p => p).Cascade(CascadeMode.StopOnFirstFailure)
               .Must(p => p.CityId!=null && p.CityId!=0).WithMessage("ورود شهر اجباری است.")
               .Must(p => !string.IsNullOrWhiteSpace(p.HomeAddress)).WithMessage("ورود آدرس محل زندگی اجباری است.")
               .Must(p => !string.IsNullOrWhiteSpace(p.PostalCode)).WithMessage("ورود کد پستی اجباری است.")

               ;
        }
    }
}