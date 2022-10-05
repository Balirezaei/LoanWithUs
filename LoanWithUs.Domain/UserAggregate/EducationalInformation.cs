using LoanWithUs.Common;
using LoanWithUs.Exceptions;

namespace LoanWithUs.Domain.UserAggregate
{
    public class EducationalInformation
    {
        CommonTextInputValidator validator = new CommonTextInputValidator(new ExceptionThrowingListener());
        public EducationalInformation(EducationLevel educationallevel, string educationalSubject)
        {
            validator.validate(educationalSubject, "آخرین مدرک تحصیلی");
            EducationalSubject = educationalSubject;
            LastEducationLevel = educationallevel;
        }

        protected EducationalInformation() { }
        public EducationLevel LastEducationLevel { get; private set; }
        public string EducationalSubject { get; private set; }

        internal void UpdateInformation(EducationLevel educationallevel, string educationalSubject)
        {
            validator.validate(educationalSubject, "آخرین مدرک تحصیلی");
            EducationalSubject = educationalSubject;
            LastEducationLevel = educationallevel;
        }
    }
}