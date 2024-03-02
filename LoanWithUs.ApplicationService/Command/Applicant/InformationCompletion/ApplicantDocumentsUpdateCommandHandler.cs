using AutoMapper;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common;
using LoanWithUs.Common.ExtentionMethod;
using LoanWithUs.Domain;
using LoanWithUs.Exceptions;
using MediatR;

namespace LoanWithUs.ApplicationService.Command
{
    public class ApplicantDocumentsUpdateCommandHandler : IRequestHandler<ApplicantDocumentsUpdateCommand, ApplicantUpdateDocumentsResult>
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IApplicantReadRepository _applicantReadRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicantDomainService _applicantDomainService;
        private readonly IFileRepository _fileRepository;
        private readonly IMapper _mapper;

        public ApplicantDocumentsUpdateCommandHandler(IApplicantRepository applicantRepository, IUnitOfWork unitOfWork, IApplicantReadRepository applicantReadRepository, IApplicantDomainService applicantDomainService, IFileRepository fileRepository, IMapper mapper)
        {
            _applicantRepository = applicantRepository;
            _unitOfWork = unitOfWork;
            _applicantReadRepository = applicantReadRepository;
            _applicantDomainService = applicantDomainService;
            _fileRepository = fileRepository;
            _mapper = mapper;
        }
        public async Task<ApplicantUpdateDocumentsResult> Handle(ApplicantDocumentsUpdateCommand request, CancellationToken cancellationToken)
        {
            var applicant = await _applicantReadRepository.FindApplicantByIdIncludeDocumentsConfirmation(request.ApplicantId);

            if (applicant == null)
                throw new NotFoundException("چنین درخواستگری موجود نیست!");

            var files = request.FileId
                                .Select(m =>
                                        {
                                            return _fileRepository.Find(m);
                                        })
                                .Select(m => m.Result)
                                .ToList();

            applicant.UpdateApplicantDucuments(files);
            _applicantRepository.Update(applicant);
            await _unitOfWork.CommitAsync();


            return new ApplicantUpdateDocumentsResult()
            {
                Message = $"تصویر {files.FirstOrDefault()?.FileType.GetDisplayName()} با موفقیت با گذاری شد.",
                Documents = applicant.UserDocuments.Select(m => _mapper.Map<FileDto>(m.File)).ToList()
            };
        }
    }

}