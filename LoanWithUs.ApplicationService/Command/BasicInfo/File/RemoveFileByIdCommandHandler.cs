using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common;
using LoanWithUs.Domain;
using LoanWithUs.Exceptions;
using MediatR;

namespace LoanWithUs.ApplicationService.Command
{
    public class RemoveFileByIdCommandHandler : IRequestHandler<RemoveFileByIdCommand>
    {
        private readonly IFileRepository _fileRepository;
        private readonly IFileService _fileService;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveFileByIdCommandHandler(IFileRepository fileRepository, IUnitOfWork unitOfWork, IFileService fileService)
        {
            _fileRepository = fileRepository;
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        public async Task<Unit> Handle(RemoveFileByIdCommand request, CancellationToken cancellationToken)
        {
            var file = await _fileRepository.Find(request.Id);
            if (file == null)
                throw new NotFoundException("چنین فایلی موجود نیست!");
            _fileService.RemoveFile(file.Path);
            _fileRepository.Delete(file);
            await _unitOfWork.CommitAsync();
            return Unit.Value;
        }
    }
}