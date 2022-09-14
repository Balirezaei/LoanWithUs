namespace LoanWithUs.Domain
{
    public enum ApplicantLoanRequestState
    {
        RejectedBySupporter = 0,
        SendByApplicant = 1,
        AcceptedBySupporter = 2,
        RejectedByAdmin = 4,
        ReadyToPay = 3,
        Paied = 5
    }

}
