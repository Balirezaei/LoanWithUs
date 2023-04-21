using LoanWithUs.Common.Enum;
using LoanWithUs.Resources;
using System.ComponentModel.DataAnnotations;

namespace LoanWithUs.Common.ExtentionMethod
{
    public static class EnumExt
    {
        public static string GetDisplayName(this MoneyType value)
        {

            try
            {
                var fieldInfo = value.GetType().GetField(value.ToString());
                var descriptionAttributes = fieldInfo.GetCustomAttributes(
                    typeof(DisplayAttribute), false) as DisplayAttribute[];
                if (descriptionAttributes == null) return string.Empty;
                return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].Name : value.ToString();
            }
            catch
            {
                return "";
            }

        }
        public static string GetDisplayName(this ApplicantLoanRequestState state)
        {
            return state switch
            {
                ApplicantLoanRequestState.ApplicantRequested => Messages.ApplicantLoanRequestState_ApplicantRequested,
                ApplicantLoanRequestState.SupporterRejected => Messages.ApplicantLoanRequestState_SupporterRejected,
                ApplicantLoanRequestState.SupporterAccepted => Messages.ApplicantLoanRequestState_SupporterAccepted,
                ApplicantLoanRequestState.AdminRejected => Messages.ApplicantLoanRequestState_AdminRejected,
                ApplicantLoanRequestState.ReadyToPay => Messages.ApplicantLoanRequestState_ReadyToPay,
                ApplicantLoanRequestState.Paied => Messages.ApplicantLoanRequestState_Paied,
                ApplicantLoanRequestState.Canceled => Messages.ApplicantLoanRequestState_Canceled
            };
        }

        public static ApplicantLoanRequestState[] GetInprogressRequestState(this ApplicantLoanRequestState state)
        {
            return new ApplicantLoanRequestState[]
            {
                ApplicantLoanRequestState.ApplicantRequested,
                ApplicantLoanRequestState.SupporterAccepted,
                ApplicantLoanRequestState.ReadyToPay,
            };
        }
    }
}
