using LoanWithUs.Common.Enum;
using LoanWithUs.Exceptions;
using LoanWithUs.Resources;

namespace LoanWithUs.Domain
{
    public abstract class ApplicantLoanRequestStateMachine
    {
        protected ApplicantLoanRequest ApplicantLoanRequest;

        protected ApplicantLoanRequestStateMachine(ApplicantLoanRequest applicantLoanRequest)
        {
            ApplicantLoanRequest = applicantLoanRequest;
        }
        public static ApplicantLoanRequestStateMachine New(ApplicantLoanRequest applicantLoanRequest, ApplicantLoanRequestState state)
        {
            
            return state switch
            {
                ApplicantLoanRequestState.ApplicantRequested => new ApplicantRequestedState(applicantLoanRequest),
                ApplicantLoanRequestState.SupporterRejected => new SupporterRejectedState(applicantLoanRequest),
                ApplicantLoanRequestState.SupporterAccepted => new SupporterAcceptedState(applicantLoanRequest),
                ApplicantLoanRequestState.AdminRejected => new AdminRejectedState(applicantLoanRequest),
                ApplicantLoanRequestState.ReadyToPay => new ReadyToPayState(applicantLoanRequest),
                ApplicantLoanRequestState.Paied => new PaiedState(applicantLoanRequest),
                _ => new CancelledState(applicantLoanRequest)
            };
        }
        public virtual void Cancel() => throw new DomainException(Messages.LoanRequestInvalidStateChange);

        public virtual void Confirm() => throw new DomainException(Messages.LoanRequestInvalidStateChange);

        public virtual void Reject() => throw new DomainException(Messages.LoanRequestInvalidStateChange);

        protected void Become(ApplicantLoanRequestState next)
        {
            ApplicantLoanRequest.LastState=next;
            ApplicantLoanRequest.StateMachine = ApplicantLoanRequestStateMachine.New(ApplicantLoanRequest, next);
        }

    }



}