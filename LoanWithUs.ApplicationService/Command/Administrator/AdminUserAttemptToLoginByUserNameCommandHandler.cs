using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common;
using LoanWithUs.Common.ExtentionMethod;
using LoanWithUs.Domain;
using LoanWithUs.Domain.UserAggregate;
using LoanWithUs.Encryption;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.ApplicationService.Command.Administrator
{
    public class AdminUserAttemptToLoginByUserNameCommandHandler : IRequestHandler<AdminUserAttemptToLoginByUserNameCommand, AdminRequestOtpResult>
    {
        private readonly IAdministratorRepository _administratorRepository;
        private readonly ILoanRSAEncryption _loanRSAEncryption;
        private readonly IUnitOfWork _unitOfWork;

        public AdminUserAttemptToLoginByUserNameCommandHandler(IAdministratorRepository administratorRepository, ILoanRSAEncryption loanRSAEncryption, IUnitOfWork unitOfWork)
        {
            _administratorRepository = administratorRepository;
            _loanRSAEncryption = loanRSAEncryption;
            _unitOfWork = unitOfWork;
        }

        public async Task<AdminRequestOtpResult> Handle(AdminUserAttemptToLoginByUserNameCommand request, CancellationToken cancellationToken)
        {
            var admin = await _administratorRepository.GetAdministratorByUserName(request.UserName.LoanTrim());
            var adminpass = _loanRSAEncryption.DecryptInput(admin.Password);
            if (adminpass != request.Password.LoanTrim())
            {
                throw new Exception("User Not Found");
            }
            var newAttempdToLogin = admin.AddNewAttempdToLogin(request.UserAgent);
            await _unitOfWork.CommitAsync();
            return new AdminRequestOtpResult(newAttempdToLogin.Key, admin.Id);
        }
    }


}
