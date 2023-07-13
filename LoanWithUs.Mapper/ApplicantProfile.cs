using AutoMapper;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Domain;
using LoanWithUs.ViewModel;

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

            CreateMap<RegisteredApplicantGridVm, RegisteredApplicantGridContract>();
            
            CreateMap<Applicant, RegisteredApplicantDto>()
                   .ForMember(m => m.FullName, opt => opt.MapFrom(src => src.PersonalInformation.FirstName + " " + src.PersonalInformation.LastName))
                   .ForMember(m => m.MobileNumber, opt => opt.MapFrom(src => src.IdentityInformation.MobileNumber))
                   .ForMember(m => m.NationalCode, opt => opt.MapFrom(src => src.IdentityInformation.NationalCode))
                ;

            CreateMap<ApplicantPersonalInformationVm, ApplicantPersonalInformationCommand>();

            CreateMap<ApplicantBanckAccountInformationVm, ApplicantAddBankInformationCommand>();
            CreateMap<ApplicantRemoveBanckAccountInformationVm, ApplicantRemoveBankAccountCommand>();
            CreateMap<ApplicantActiveBanckAccountInformationVm, ApplicantActiveCurrentBanckAccountCommand>();
            CreateMap<ApplicantAddressInformationVm, ApplicantAddressInformationCommand>();
             

        }
    }

}