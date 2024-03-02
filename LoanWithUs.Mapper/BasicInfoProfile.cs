using AutoMapper;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.ApplicationService.Contract.Administrator;
using LoanWithUs.Common.DefinedType;
using LoanWithUs.Common.ExtentionMethod;
using LoanWithUs.Domain;
using LoanWithUs.ViewModel;

namespace LoanWithUs.Mapper
{
    public class BasicInfoProfile : Profile
    {
        public BasicInfoProfile()
        {
            CreateMap<LoanWithUsFile, FileDto>();
            CreateMap<LoanWithUsFile, CreateFileCommandResult>();
            
            CreateMap<LoanLadderFrame, LoanLadderFrameDto>()
                .ForMember(desc => desc.Amount, opt => opt.MapFrom(o => $"{o.Amount.amount.ToStringSplit3Digit()} {o.Amount.moneyType.GetDisplayName()}"))
                .ForMember(desc => desc.Installments, opt => opt.MapFrom(o => string.Join(',', o.AvalableInstallments.Select(z => z.Count).ToArray())))
                .ForMember(desc => desc.ParentId, opt => opt.MapFrom(o => o.RequiredParentLoanId))
                ;

             
            CreateMap< City, CityDto>();
            CreateMap<FileDto, LoanWithUsFile>();


            CreateMap<LoanLadderFrameContractGridContractVm, LoanLadderFrameContractGridContract>();


            CreateMap<SupporterRegistereApplicantVm, SupporterRegistereApplicantCommand>()
                   .ForMember(desc => desc.MobileNumber, opt => opt.MapFrom(o => new MobileNumber(o.MobileNumber)))
                ;


        }
    }
}