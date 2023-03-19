using AutoMapper;
using LoanWithUs.ApplicationService.Contract.Administrator;
using LoanWithUs.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.ApplicationService.Query.Administrator
{
    public class LoanLadderFrameContractGridContractHandler : IRequestHandler<LoanLadderFrameContractGridContract, List<LoanLadderFrameDto>>
    {
        private readonly ILoanLadderFrameRepository _ladderFrameRepository;
        private readonly IMapper _mapper;

        public LoanLadderFrameContractGridContractHandler(ILoanLadderFrameRepository ladderFrameRepository, IMapper mapper)
        {
            _ladderFrameRepository = ladderFrameRepository;
            _mapper = mapper;
        }

        public async Task<List<LoanLadderFrameDto>> Handle(LoanLadderFrameContractGridContract request, CancellationToken cancellationToken)
        {
            var ladders = await _ladderFrameRepository.GetAllLoanLadder().DoCommonPagin(request);
            return _mapper.Map<List<LoanLadderFrameDto>>(ladders);
        }

    } 
}
    

