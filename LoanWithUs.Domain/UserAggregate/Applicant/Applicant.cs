﻿using LoanWithUs.Common;
using LoanWithUs.Common.DefinedType;
using LoanWithUs.Common.Enum;
using LoanWithUs.Common.ExtentionMethod;
using LoanWithUs.Exceptions;
using LoanWithUs.Resources;

namespace LoanWithUs.Domain
{
    /// <summary>
    /// درخواستگر
    /// </summary>
    public partial class Applicant : User
    {
        protected Applicant() { }

        public virtual LoanLadderFrame CurrentLoanLadderFrame { get; private set; }
        public virtual List<ApplicantLoanLadder> ApplicantLoanLadderHistory { get; set; }
        public int CurrentLoanLadderFrameId { get; private set; }

        public virtual Supporter Supporter { get; private set; }
        public int SupporterId { get; private set; }
        public virtual List<ApplicantLoanRequest> LoanRequests { get; set; }
        //public List<ApplicantConfirmationRequest> ConfirmationRequests { get; set; }

        //public void RequestToCheckInformation(IDateTimeServiceProvider dateProvider)
        //{
        //    if (ConfirmationRequests == null)
        //    {
        //        ConfirmationRequests = new List<ApplicantConfirmationRequest>();
        //    }
        //    if (ConfirmationRequests.Any(m => m.IsProccessed == false))
        //    {
        //        throw new DomainException("درخواست شما در دست بررسی می باشد ،");
        //    }
        //    ConfirmationRequests.Add(new ApplicantConfirmationRequest(dateProvider.GetDate()));
        //}


        //public Loan ActiveLoan { get; set; }

        #region LoanRequest
        public ApplicantLoanRequest RequestNewLoan(string reason, string description, Amount amount, LoanLadderInstallmentsCount installmentsCount, IApplicantLoanRequestDomainService _applicantLoanRequestDomainService, IDateTimeServiceProvider dateProvider)
        {

            if (this.UserConfirmation == null || !this.UserConfirmation.TotalConfirmation)
                throw new DomainException(Messages.ApplicantLoanRequestNotConfirmedInfo);

            var supporterCredit = Supporter.GetAvailableCredit();
            if (supporterCredit < amount)
            {
                throw new DomainException(Messages.ApplicantLoanRequestInsufficientSupporterCredit);
            }

            if (amount > CurrentLoanLadderFrame.Amount)
            {
                throw new InvalidDomainInputException(Messages.ApplicantLoanRequestInvalidAmount);
            }

            var request = new ApplicantLoanRequest(this, Supporter, CurrentLoanLadderFrame, installmentsCount, amount, reason, description, _applicantLoanRequestDomainService, dateProvider);
            if (LoanRequests == null)
            {
                LoanRequests = new List<ApplicantLoanRequest>();
            }
            LoanRequests.Add(request);

            return request;

        }
        public ApplicantLoanRequest DeactiveLoanRequest(IApplicantLoanRequestDomainService domainService)
        {
            if (domainService.HasOpenRequest(this).Result)
            {
                var inprogressState = ApplicantLoanRequestState.ApplicantRequested.GetInprogressRequestState();

                var openRequest = LoanRequests.Where(m => inprogressState.Contains(m.LastState)).FirstOrDefault();
                openRequest.StateMachine.Cancel();

                return openRequest;
            }
            throw new Exception(Messages.LoanRequestInvalidStateChange);
        }

        #endregion


        ////ToDo:Remove Imediatelyyy
        //public Applicant(MobileNumber mobileNumber, string nationalCode)
        //{
        //    var isAvailable = false;// domainService.IsMobileReservedWithOtherUserType(mobileNumber).Result;
        //    if (isAvailable)
        //    {
        //        throw new InvalidDomainInputException("امکان ثبت نام شماره تلفن به عنوان درخواستگر فراهم نمی باشد.لطفن با مدیر سامانه تماس بگیرید.");
        //    }
        //    this.IdentityInformation = new IdentityInformation(mobileNumber, nationalCode);
        //    //this.UserLogins = this.UserLogins ?? new List<UserLogin>();
        //    //this.UserLogins.Add(new UserLogin(DateTime.Now.AddMinutes(2)));
        //    this.RegisterationDate = DateTime.Now;
        //}

        /// <summary>
        ///It should be Internal beacuse of client can not create new instance of Applicant
        ///And Only Supporter can register new Applicant
        /// </summary>
        /// <param name="mobileNumber"></param>
        /// <param name="domainService"></param>
        /// <exception cref="InvalidDomainInputException"></exception>
        internal Applicant(Supporter supporter, MobileNumber mobileNumber, string nationalCode, string firstName, string lastName, IApplicantDomainService domainService, IDateTimeServiceProvider dateProvider)
        {
            var isMobileAvailable = domainService.IsMobileReservedWithAllUserType(Id, mobileNumber).Result;
            if (isMobileAvailable)
            {
                throw new InvalidDomainInputException("امکان ثبت نام شماره تلفن به عنوان درخواستگر فراهم نمی باشد.لطفن با مدیر سامانه تماس بگیرید.");
            }
            Supporter = supporter;

            var isNationalCodeAvailable = domainService.IsNationalReservedWithAllUserType(Id, nationalCode).Result;
            if (isNationalCodeAvailable)
            {
                throw new InvalidDomainInputException("to do.");
            }
            IdentityInformation = new IdentityInformation(mobileNumber, nationalCode);
            PersonalInformation = new PersonalInformation(firstName, lastName);

            CurrentLoanLadderFrame = domainService.InitLoaderForApplicant().Result;
            CurrentLoanLadderFrameId = domainService.InitLoaderForApplicant().Result.Id;

            this.ApplicantLoanLadderHistory = new List<ApplicantLoanLadder>
            {
                new ApplicantLoanLadder(CurrentLoanLadderFrameId, "نردبان یکم _ ثبت نام درخواستگر", dateProvider)
            };

            RegisterationDate = dateProvider.GetDate();

            UserConfirmation = UserConfirmation.NotConfirmedInstance();

        }

        public void UpdatePersonalInformation(PersonalInformation personalInformation)
        {
            if (PersonalInformation == null)
            {
                PersonalInformation = personalInformation;
            }
            else
            {
                PersonalInformation.Update(
                                            personalInformation.FirstName,
                                            personalInformation.LastName,
                                            personalInformation.MotherFullName,
                                            personalInformation.FatherFullName,
                                            personalInformation.BirthDate,
                                            personalInformation.IdentityNumber,
                                            personalInformation.Job,
                                            personalInformation.IsMale,
                                            personalInformation.IsMarried,
                                            personalInformation.ChildrenCount,
                                            personalInformation.MinimumIncome);
            }
        }

        public void UpdateEducationalInformation(EducationLevel educationallevel, string educationalSubject)
        {
            if (EducationalInformation == null)
            {
                EducationalInformation = new EducationalInformation(educationallevel, educationalSubject);
            }
            else
            {
                EducationalInformation.UpdateInformation(educationallevel, educationalSubject);
            }
        }

        public void AddBankInformation(string shabaNumber, string cardNumber, BankType bankType, bool isActive)
        {
            if (BankAccountInformations == null)
            {
                BankAccountInformations = new List<BankAccountInformation>();
            }

            if (this.BankAccountInformations.Count > 2)
            {
                throw new DomainException(Messages.ExceptionOnExtraBanckAccount);
            }

            if (this.BankAccountInformations.Any(m => m.IsActive))
            {
                isActive = false;
            }


            if (this.BankAccountInformations.Any(m => m.ShabaNumber == shabaNumber || m.BankCartNumber == cardNumber))
            {
                throw new DomainException(Messages.ExceptionOnRepetetiveBanck);
            }

            var bankIformation = new BankAccountInformation(shabaNumber, cardNumber, bankType, isActive);
            BankAccountInformations.Add(bankIformation);
        }

        public void RemoveBanckAccount(string shabaNumber)
        {
            var banckAccount = this.BankAccountInformations.First(m => m.ShabaNumber == shabaNumber);
            if (banckAccount != null)
            {
                this.BankAccountInformations.Remove(banckAccount);
            }
        }
        public void ActiveCurrentBanckAccount(string shabaNumber)
        {
            foreach (var item in this.BankAccountInformations)
            {
                if (item.ShabaNumber == shabaNumber)
                {
                    item.IsActive = true;
                }
                else
                {
                    item.IsActive = false;
                }
            }
        }


        internal void ConfirmInfo()
        {
            this.UserConfirmation = new UserConfirmation(true, true, true, true, true);
        }


        public void MoveToNextLadderAfterLoanSettel(IApplicantDomainService domainService, IDateTimeServiceProvider dateProvider)
        {
            var next = domainService.NextLadderForApplicant(this.CurrentLoanLadderFrame).Result;

            if (next != null)
            {
                this.CurrentLoanLadderFrame = next;
                this.ApplicantLoanLadderHistory.Add(new ApplicantLoanLadder(next.Id, "وام تسویه شده", dateProvider));
            }
        }

        public void UpdateApplicantDucuments(List<LoanWithUsFile> files)
        {
            //this.UserDocuments.Clear();
            //this.UserDocuments = files.Select(m =>
            //{
            //    return new UserDocument(m);
            //}).ToList();
            foreach (var file in files)
            {
                if (this.UserDocuments.Any(m => m.File.FileType == file.FileType))
                {
                    var first = this.UserDocuments.First(m => m.File.FileType == file.FileType);

                    this.UserDocuments.Remove(first);
                }
                this.UserDocuments.Add(new UserDocument(file));
            }

        }

        public void UpdateAddressInformation(AddressInformation addressInformation)
        {
            if (this.AddressInformation == null)
            {
                this.AddressInformation = addressInformation;
            }
            else
            {
                this.AddressInformation.UpdateByNewValue(addressInformation);
            }
        }
    }

}