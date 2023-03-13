using FluentValidation;
using LoanWithUs.ApplicationService.Contract;

namespace LoanWithUs.ApplicationService.Command.Supporter
{
    public class SupporterRegistereApplicantCommandValidator : AbstractValidator<SupporterRegistereApplicantCommand>
    {
        public SupporterRegistereApplicantCommandValidator()
        {
            RuleFor(v => v.FirstName)
            .NotEmpty()
            .WithMessage("ورود نام اجباریست.");

            RuleFor(v => v.LastName)
            .NotEmpty()
            .WithMessage("ورود نام خانوادگی اجباریست.");

            RuleFor(v => v.NationalCode)
            .NotEmpty()
            .WithMessage("ورود کد ملی اجباریست.");

            RuleFor(v => v.NationalCode)
                .Custom((x, context) =>
            {
                if ((!(long.TryParse(x, out long value)) || value < 0))
                {
                    context.AddFailure($"فرمت کد ملی صحیح نیست");
                }
            });

            RuleFor(v => v.MobileNumber)
            .NotEmpty()
            .WithMessage("ورود شماره موبایل اجباریست.");

            RuleFor(v => v.MobileNumber)
                .Custom((x, context) =>
            {
                var mobile = x.ToString();
                if ((!(long.TryParse(mobile, out long value)) || value < 0))
                {
                    context.AddFailure($"فرمت شماره موبایل صحیح نیست");
                }
            });
        }
    }
}
