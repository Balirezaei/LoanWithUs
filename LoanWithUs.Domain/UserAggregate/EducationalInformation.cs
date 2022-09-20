using LoanWithUs.Exceptions;

namespace LoanWithUs.Domain.UserAggregate
{
    public class EducationalInformation
    {
        CommonTextInputValidator validator = new CommonTextInputValidator(new ExceptionThrowingListener());
        public EducationalInformation(string educationalSubject, string lastEducationTitle)
        {
            validator.validate(educationalSubject, "عنوان آخرین مدرک تحصیلی");
            validator.validate(lastEducationTitle, "آخرین مدرک تحصیلی");
            EducationalSubject = educationalSubject;
            LastEducationTitle = lastEducationTitle;
        }

        protected EducationalInformation() { }
        public string LastEducationTitle { get; private set; }
        public string EducationalSubject { get; private set; }

        internal void UpdateInformation(string educationalSubject, string lastEducationTitle)
        {
            validator.validate(educationalSubject, "عنوان آخرین مدرک تحصیلی");
            validator.validate(lastEducationTitle, "آخرین مدرک تحصیلی");
            EducationalSubject = educationalSubject;
            LastEducationTitle = lastEducationTitle;
        }
    }
}