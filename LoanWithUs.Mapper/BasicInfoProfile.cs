using AutoMapper;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Domain;

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