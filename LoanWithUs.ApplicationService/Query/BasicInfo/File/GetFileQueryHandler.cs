using AutoMapper;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Domain.BasicInfo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.ApplicationService.Query.BasicInfo.File
{
    public class GetFileQueryHandler : IRequestHandler<GetFileByIdQuery, FileDto>
    {
        private readonly IFileRepository _fileRepository;
        private readonly IMapper _mapper;

        public GetFileQueryHandler(IFileRepository fileRepository, IMapper mapper)
        {
            _fileRepository = fileRepository;
            _mapper = mapper;
        }

        public async Task<FileDto> Handle(GetFileByIdQuery request, CancellationToken cancellationToken)
        {
            var file = await _fileRepository.Find(request.Id);
            return _mapper.Map<FileDto>(file);
        }
    }
}
