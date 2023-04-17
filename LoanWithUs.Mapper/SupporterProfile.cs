using AutoMapper;
using LoanWithUs.ApplicationService.Contract.Administrator;
using LoanWithUs.Common.DefinedType;
using LoanWithUs.Common.ExtentionMethod;
using LoanWithUs.Domain;
using LoanWithUs.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.Mapper
{
    public class SupporterProfile : Profile
    {
        public SupporterProfile()
        {
            CreateMap<Supporter, AdminRegisteredSupporterDto>()
                .ForMember(desc => desc.FullName, opt => opt.MapFrom(o => $"{o.PersonalInformation.FirstName} {o.PersonalInformation.LastName}"))
                .ForMember(desc => desc.NationalCode, opt => opt.MapFrom(o =>o.IdentityInformation.NationalCode))
                .ForMember(desc => desc.MobileNo, opt => opt.MapFrom(o =>o.IdentityInformation.MobileNumber))
                .ForMember(desc => desc.RegisterationDate, opt => opt.MapFrom(o =>o.RegisterationDate.M2S()))
                ;

            CreateMap<AdminRegisteredSupporterVm, AdminRegisteredSupporterContract>()
                 
                ;
            CreateMap<AdminRegisterSupporterVm, AdminRegisterSupporterCommand>()
                  .ForMember(desc => desc.MobileNumber, opt => opt.MapFrom(o => new MobileNumber(o.MobileNumber)))
                ;
            
                
        }
    }

}
