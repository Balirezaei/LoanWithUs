namespace LoanWithUs.Common.Enum
{
    //public enum ApplicantLoanRequestState
    //{
    //    HasActiveLoan = 1,
    //    InsufficientSupporterCredit = 2,
    //    ReadyToLoanRequest = 3
    //}

    public enum ApplicantLoanRequestState
    {
        ApplicantRequested = 1,
        SupporterRejected = 2,
        SupporterAccepted = 3,
        AdminRejected = 4,
        ReadyToPay = 5,
        Paied = 6,
        Canceled = 7
    }
}
