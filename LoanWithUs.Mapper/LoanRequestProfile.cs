using AutoMapper;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.ApplicationService.Contract.Applicant;
using LoanWithUs.Common.ExtentionMethod;
using LoanWithUs.Domain;
using LoanWithUs.ViewModel;

namespace LoanWithUs.Mapper
{
    public class LoanRequestProfile : Profile
    {
        public LoanRequestProfile()
        {
            CreateMap<ApplicantRequestLoanVm, ApplicantRequestLoanCommand>()
              .ForMember(m => m.Amount, opt => opt.MapFrom(src => src.Amount.ToToman()));

            CreateMap<ApplicantLoanRequest, ApplicantLoanRequestDto>();

            CreateMap<ApplicantLoanRequest, ApplicantRequestGrid>()
                    .ForMember(m => m.CreateDate, opt => opt.MapFrom(src => src.CreateDate.M2SWithTime()))
                    .ForMember(m => m.Amount, opt => opt.MapFrom(src => src.Amount.amount))
                    .ForMember(m => m.ApplicantFullName, opt => opt.MapFrom(src => src.Applicant.DisplayName()))
                    .ForMember(m => m.StateDescription, opt => opt.MapFrom(src => src.LastState.GetDisplayName()))
                    .ForMember(m => m.InstallmentsCount, opt => opt.MapFrom(src => src.InstallmentsCount))
                    .ForMember(m => m.State, opt => opt.MapFrom(src => src.LastState))
                ;

            CreateMap<ApplicantOpenRequestGridVm, SupporterOpenApplicantRequestGridContract>();
            CreateMap<ApplicantOpenRequestGridVm, AdminOpenApplicantRequestGridContract>();



            CreateMap<ApplicantLoanRequest, AdminApplicantRequestGrid>()
                    .ForMember(m => m.CreateDate, opt => opt.MapFrom(src => src.CreateDate.M2SWithTime()))
                    .ForMember(m => m.Amount, opt => opt.MapFrom(src => src.Amount.amount))
                    .ForMember(m => m.ApplicantFullName, opt => opt.MapFrom(src => src.Applicant.DisplayName()))
                    .ForMember(m => m.SupporterFullName, opt => opt.MapFrom(src => src.Supporter.DisplayName()))
                    .ForMember(m => m.StateDescription, opt => opt.MapFrom(src => src.LastState.GetDisplayName()))
                    .ForMember(m => m.InstallmentsCount, opt => opt.MapFrom(src => src.InstallmentsCount))
                    .ForMember(m => m.State, opt => opt.MapFrom(src => src.LastState))

                    ;


            CreateMap<ApplicantLoanRequest, CurrentApplicantLoanRequestDetail>()
                .ForMember(m => m.LastStateDescription, opt => opt.MapFrom(src => src.LastState.GetDisplayName()))
                .ForMember(m => m.Amount, opt => opt.MapFrom(src => src.Amount.amount.ToStringSplit3Digit()))
                .ForMember(m => m.InstallmentsCount, opt => opt.MapFrom(src => src.InstallmentsCount))

                ;
            CreateMap<ApplicantLoanRequestFlow, CurrentApplicantLoanRequestFlow>()
                .ForMember(m => m.StateDescription, opt => opt.MapFrom(src => src.State.GetDisplayName()))
                .ForMember(m => m.CreateDate, opt => opt.MapFrom(src => src.CreateDate.M2SWithTime()))
                ;





        }
    }

}