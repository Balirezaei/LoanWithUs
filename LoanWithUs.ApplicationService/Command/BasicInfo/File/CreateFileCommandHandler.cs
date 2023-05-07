using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common;
using LoanWithUs.Domain;
using MediatR;

namespace LoanWithUs.ApplicationService.Command
{
    public class CreateFileCommandHandler : IRequestHandler<CreateFileCommand, CreateFileCommandResult>
    {
        private readonly FileSettings _fileSettings;
        private readonly IFileRepository _fileRepository;
        private readonly IFileService _fileService;
        private readonly IUnitOfWork _unitOfWork;

        public CreateFileCommandHandler(FileSettings fileSettings, IFileRepository fileRepository, IUnitOfWork unitOfWork, IFileService fileService)
        {
            _fileSettings = fileSettings;
            _fileRepository = fileRepository;
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        public async Task<CreateFileCommandResult> Handle(CreateFileCommand request, CancellationToken cancellationToken)
        {
            var name = DateTime.Now.Ticks + Path.GetExtension(request.File.FileName);
            var filePath = _fileSettings.PhysicalFilePath + name;
            var url = _fileSettings.FileNetworkUrl + name;
            var file = new LoanWithUsFile(filePath, request.File.FileName, Path.GetExtension(request.File.FileName), url, request.FileType);
            await _fileService.WriteFile(request.File, filePath);
            await _fileRepository.Create(file);
            await _unitOfWork.CommitAsync();
            return new CreateFileCommandResult()
            {
                Id = file.Id,
                Url = url,
                Path = filePath,
                Name = name
            };
        }
    }
}
