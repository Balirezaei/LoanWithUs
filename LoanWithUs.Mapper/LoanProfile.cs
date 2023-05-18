using AutoMapper;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Common;
using LoanWithUs.Common.ExtentionMethod;
using LoanWithUs.Domain;

namespace LoanWithUs.Mapper
{
    public class LoanProfile : Profile
    {
        public LoanProfile()
        {
        }

        public LoanProfile(IDateTimeServiceProvider dateProvider)
        {

            CreateMap<LoanInstallment, ApplicantLoanRequestInstallmentDto>()
                  .ForMember(m => m.Amount, opt => opt.MapFrom(src => src.Amount.ToStringSplit3Digit()))
                  .ForMember(m => m.EndDateForPay, opt => opt.MapFrom(src => src.EndDate.M2S()))
                  .ForMember(m => m.StartDateForPay, opt => opt.MapFrom(src => src.StartDate.M2S()))
                  .ForMember(m => m.PenaltyDay, opt => opt.MapFrom(src => src.PenaltyDay))
                  .ForMember(m => m.PenaltyFee, opt => opt.MapFrom(src => src.PenaltyFee.ToStringSplit3Digit()))
                  .ForMember(m => m.IsPaid, opt => opt.MapFrom(src => src.PaiedDate != null))
                     .ForMember(m => m.PaidDate, opt => opt.MapFrom(src => src.PaiedDate != null ? src.PaiedDate.Value.M2S() : ""))
                     .ForMember(m => m.Step, opt => opt.MapFrom(src => src.Step))
                      .ForMember(m => m.ReadyToPay, opt => opt.MapFrom(src => src.PaiedDate == null && src.StartDate < dateProvider.GetDate()))
                ;

            CreateMap<Loan, ActiveApplicantLoan>()
                 .ForMember(dest => dest.Installments, opt => opt.MapFrom(x => x.GetLoanInstallmentsWithPenaltyCalculation(dateProvider)))
                 .ForMember(dest => dest.ReceiptFile, opt => opt.MapFrom(x => x.ReciptFile))
                 .ForMember(dest => dest.LoanId, opt => opt.MapFrom(x => x.Id))
                 .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(x => x.LoanInstallments.Sum(m => m.Amount).ToStringSplit3Digit()))
                 .ForMember(dest => dest.CanBeSettled, opt => opt.MapFrom(x => x.LoanInstallments.Any(m => m.PaiedDate != null)))
                    .ForMember(m => m.StartDate, opt => opt.MapFrom(src => src.StartDate.M2S()))
 .ForMember(m => m.WageAmount, opt => opt.MapFrom(src => $"{(src.Amount.amount * src.LoanWage).ToString("#,##0")} {src.Amount.moneyType.GetDisplayName()}"))
                    .ForMember(m => m.Amount, opt => opt.MapFrom(src => $"{src.Amount.amount.ToStringSplit3Digit()} {src.Amount.moneyType.GetDisplayName()}"))
                    .ForMember(m => m.SupporterFullName, opt => opt.MapFrom(src => src.LoanRequiredDocuments.FirstOrDefault(m => m.Type == Common.LoanRequiredDocumentType.Supporter).Description.UserFullName))
                   ;
            CreateMap<Loan, SupporterApplicantsActiveLoanDto>()
             //.ForMember(dest => dest.Installments, opt => opt.MapFrom(x => x.LoanInstallments))
             //.ForMember(dest => dest.ReceiptFile, opt => opt.MapFrom(x => x.ReciptFile))
             .ForMember(m => m.StartDate, opt => opt.MapFrom(src => src.StartDate.M2S()))
                 .ForMember(m => m.WageAmount, opt => opt.MapFrom(src => $"{(src.Amount.amount * src.LoanWage).ToString("#,##0")} {src.Amount.moneyType.GetDisplayName()}"))
            .ForMember(m => m.Amount, opt => opt.MapFrom(src => $"{src.Amount.amount.ToStringSplit3Digit()} {src.Amount.moneyType.GetDisplayName()}"))
             .ForMember(m => m.RemainingAmount, opt => opt.MapFrom(src => (src.LoanInstallments.Sum(m => m.Amount) - src.LoanInstallments.Where(m => m.PaiedDate != null).Sum(m => m.Amount)).ToStringSplit3Digit()))
             .ForMember(m => m.ApplicantFullName, opt => opt.MapFrom(src => src.Requester.DisplayName()))
            ;


        }
    }

}