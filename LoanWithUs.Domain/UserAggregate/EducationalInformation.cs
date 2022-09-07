namespace LoanWithUs.Domain.UserAggregate
{
    public class EducationalInformation
    {
        protected EducationalInformation() { }
        public string LastEducationTitle { get; private set; }
        public string EducationalSubject { get; private set; }
    }
}