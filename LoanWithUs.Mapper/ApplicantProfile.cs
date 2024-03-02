using AutoMapper;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common.ExtentionMethod;
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
                .ForMember(m=>m.ApplicantBankInformations, opt => opt.MapFrom(src=>src.BankAccountInformations))
                .ForMember(m=>m.ApplicantDocuments, opt => opt.MapFrom(src=>src.UserDocuments))
                ;

            CreateMap<EducationalInformation, ApplicantEductionalInformationDto>();

            CreateMap<UserDocument, FileDto>()
                .ForMember(m=>m.FileName,opt=>opt.MapFrom(src=>src.File.FileName))
                .ForMember(m=>m.FileType,opt=>opt.MapFrom(src=>src.File.FileType))
                .ForMember(m=>m.Path,opt=>opt.MapFrom(src=>src.File.Path))
                .ForMember(m=>m.Id,opt=>opt.MapFrom(src=>src.File.Id))
                .ForMember(m=>m.FileUrl,opt=>opt.MapFrom(src=>src.File.FileUrl))
                ;
            
            CreateMap<PersonalInformation, ApplicantPersonalInformationDto>();

            CreateMap<AddressInformation, ApplicantAddressInformationDto>();
            CreateMap<BankAccountInformation, ApplicantBankInformationDto>()
                .ForMember(m=>m.BankTypeDescription, opt=>opt.MapFrom(src=>src.BankType.GetDisplayName()));


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