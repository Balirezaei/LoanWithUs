using FluentValidation;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Domain.UserAggregate;

namespace LoanWithUs.ApplicationService.Command
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        //private readonly IApplicantReadRepository _applicantRepository;
        public LoginUserCommandValidator()
        {
            //_applicantRepository = applicantRepository;

            RuleFor(v => v.Mobile)
                .NotEmpty().WithMessage("شماره موبایل اجباریست.")
                //.MaximumLength(200).WithMessage("Title must not exceed 200 characters.")
                //.MustAsync(BeUniqueTitle).WithMessage("The specified title already exists.")
                ;
        }

        //public Task<bool> BeUniqueTitle(string mobile, CancellationToken cancellationToken)
        //{
        //    return _applicantRepository.IsUserMobileExist(mobile);
        //}
    }
}