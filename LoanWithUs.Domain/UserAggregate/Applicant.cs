using LoanWithUs.Exceptions;

namespace LoanWithUs.Domain.UserAggregate
{
    /// <summary>
    /// درخواستگر
    /// </summary>
    public class Applicant : User
    {
        protected Applicant() { }
        public Applicant(string mobileNumber, IApplicantDomainService domainService)
        {
            var isAvailable = domainService.IsMobileReservedWithOtherUserType(mobileNumber).Result;
            if (isAvailable)
            {
                throw new InvalidDomainInputException("امکان ثبت نام شماره تلفن به عنوان درخواستگر فراهم نمی باشد.لطفن با مدیر سامانه تماس بگیرید.");
            }
            this.IdentityInformation = new IdentityInformation(mobileNumber);
            this.UserLogins = this.UserLogins ?? new List<UserLogin>();
            this.UserLogins.Add(new UserLogin(DateTime.Now.AddMinutes(2)));
        }

        public void AddNewLogin()
        {
            this.UserLogins.Add(new UserLogin(DateTime.Now.AddMinutes(2)));
        }

        public void UpdateEducationalInformation(string educationalSubject, string lastEducationlevel)
        {
            if (this.EducationalInformation==null)
            {
                this.EducationalInformation = new EducationalInformation(educationalSubject, lastEducationlevel);
            }
            else
            {
                this.EducationalInformation.UpdateInformation(educationalSubject, lastEducationlevel);
            }
        }
    }

}