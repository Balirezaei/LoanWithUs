using AutoMapper;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Domain.UserAggregate;

namespace LoanWithUs.Mapper
{
    public class ApplicantProfile : Profile
    {
        public ApplicantProfile()
        {
            CreateMap<Applicant, ApplicantDto>()
                .ForMember(m => m.EducationalSubject, opt => opt.MapFrom(src => src.EducationalInformation != null ? src.EducationalInformation.EducationalSubject : null))
                .ForMember(m => m.LastEducationLevel, opt => opt.MapFrom(src => src.EducationalInformation != null ? src.EducationalInformation.LastEducationLevel : 0))
                ;
        }
    }
  
}