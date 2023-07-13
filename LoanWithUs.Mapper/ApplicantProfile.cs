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
                .ForMember(m=>m.ApplicantEductionalInformation,opt=>opt.MapFrom(src=>src.EducationalInformation))
                .ForMember(m=>m.ApplicantPersonalInformation, opt=>opt.MapFrom(src=>src.PersonalInformation))
                .ForMember(m=>m.ApplicantAddressInformation, opt=>opt.MapFrom(src=>src.AddressInformation))
                .ForMember(m=>m.ApplicantAddBankInformations, opt => opt.MapFrom(src=>src.BankAccountInformations))
                
                ;

            CreateMap<EducationalInformation, ApplicantEductionalInformationDto>();
            CreateMap<PersonalInformation, ApplicantPersonalInformationDto>();
            CreateMap<AddressInformation, ApplicantAddressInformationDto>();
            CreateMap<BankAccountInformation, ApplicantAddBankInformationDto>();


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