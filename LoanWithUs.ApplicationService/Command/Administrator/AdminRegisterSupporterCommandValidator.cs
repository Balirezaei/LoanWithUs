using FluentValidation;
using LoanWithUs.ApplicationService.Contract.Administrator;

namespace LoanWithUs.ApplicationService.Command.Administrator
{
    public class AdminRegisterSupporterCommandValidator : AbstractValidator<AdminRegisterSupporterCommand>
    {
        public AdminRegisterSupporterCommandValidator()
        {
            RuleFor(v => v.NationalCode)
                .NotEmpty().WithMessage("ورود کد ملی اجباریست.");

            RuleFor(v => v.NationalCode).Custom((x, context) =>
                {
                    if ((!(int.TryParse(x, out int value)) || value < 0))
                    {
                        context.AddFailure($"فرمت کد ملی صحیح نیست");
                    }
                });

            RuleFor(v => v.MobileNo)
            .NotEmpty().WithMessage("ورود شماره موبایل اجباریست.");
        }
    }


}
