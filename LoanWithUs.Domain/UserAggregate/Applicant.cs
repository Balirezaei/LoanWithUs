using LoanWithUs.Common;
using LoanWithUs.Exceptions;

namespace LoanWithUs.Domain.UserAggregate
{
    /// <summary>
    /// درخواستگر
    /// </summary>
    public class Applicant : User
    {
        protected Applicant() { }

        //ToDo:Remove Imediatelyyy
        public Applicant(string mobileNumber, string nationalCode)
        {
            var isAvailable = false;// domainService.IsMobileReservedWithOtherUserType(mobileNumber).Result;
            if (isAvailable)
            {
                throw new InvalidDomainInputException("امکان ثبت نام شماره تلفن به عنوان درخواستگر فراهم نمی باشد.لطفن با مدیر سامانه تماس بگیرید.");
            }
            this.IdentityInformation = new IdentityInformation(mobileNumber, nationalCode);
            //this.UserLogins = this.UserLogins ?? new List<UserLogin>();
            //this.UserLogins.Add(new UserLogin(DateTime.Now.AddMinutes(2)));
            this.RegisterationDate = DateTime.Now;
        }

        /// <summary>
        ///It should be Internal beacuse of client can not create new instance of Applicant
        ///And Only Supporter can register new Applicant
        /// </summary>
        /// <param name="mobileNumber"></param>
        /// <param name="domainService"></param>
        /// <exception cref="InvalidDomainInputException"></exception>
        internal Applicant(string mobileNumber,string nationalCode,string firstName,string lastName, IApplicantDomainService domainService)
        {
            var isAvailable = domainService.IsMobileReservedWithOtherUserType(mobileNumber).Result;
            if (isAvailable)
            {
                throw new InvalidDomainInputException("امکان ثبت نام شماره تلفن به عنوان درخواستگر فراهم نمی باشد.لطفن با مدیر سامانه تماس بگیرید.");
            }
            this.IdentityInformation = new IdentityInformation(mobileNumber, nationalCode);
            //this.UserLogins = this.UserLogins ?? new List<UserLogin>();
            //this.UserLogins.Add(new UserLogin(DateTime.Now.AddMinutes(2)));
            this.RegisterationDate = DateTime.Now;
        }



        public void UpdateEducationalInformation(EducationLevel educationallevel, string educationalSubject)
        {
            if (this.EducationalInformation==null)
            {
                this.EducationalInformation = new EducationalInformation(educationallevel, educationalSubject);
            }
            else
            {
                this.EducationalInformation.UpdateInformation(educationallevel, educationalSubject);
            }
        }
    }

}