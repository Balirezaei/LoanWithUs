using AutoMapper;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.ApplicationService.Contract.Administrator;
using LoanWithUs.Domain;
using LoanWithUs.ViewModel;

namespace LoanWithUs.Mapper
{
    public class BasicInfoProfile : Profile
    {
        public BasicInfoProfile()
        {
            CreateMap<LoanWithUsFile, FileDto>();

            CreateMap<LoanLadderFrame, LoanLadderFrameDto>();
            CreateMap<LoanLadderFrameContractGridContractVm, LoanLadderFrameContractGridContract>();
        }
    }
}