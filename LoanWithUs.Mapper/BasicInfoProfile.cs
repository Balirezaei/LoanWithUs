using AutoMapper;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Domain.BasicInfo;

namespace LoanWithUs.Mapper
{
    public class BasicInfoProfile : Profile
    {
        public BasicInfoProfile()
        {
            CreateMap<LoanWithUsFile, FileDto>();
        }
    }
}