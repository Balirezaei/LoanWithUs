﻿using FluentValidation;
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
                    if ((!(long.TryParse(x, out long value)) || value < 0))
                    {
                        context.AddFailure($"فرمت کد ملی صحیح نیست");
                    }
                });

            RuleFor(v => v.MobileNumber)
            .NotEmpty().WithMessage("ورود شماره موبایل اجباریست.");
        }
    }


}
