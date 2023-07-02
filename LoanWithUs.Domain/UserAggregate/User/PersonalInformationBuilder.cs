namespace LoanWithUs.Domain
{
    public class PersonalInformationBuilder
    {
        private string firstName;
        private string lastName;
        private string motherFullName;
        private string fatherFullName;
        private DateTime birthDate;
        private string identityNumber;
        private string job;
        private bool isMale;
        private bool isMarried;
        private int childrenCount;
        private int minimumIncom;

        public PersonalInformationBuilder WithNameAndGender(string firstName, string lastName, bool isMale)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.isMale = isMale;
            return this;
        }

        public PersonalInformationBuilder WithParentName(string motherFullName, string fatherFullName)
        {

            this.motherFullName = motherFullName;
            this.fatherFullName = fatherFullName;
            return this;
        }
        public PersonalInformationBuilder WithMarriageInfo(bool isMarried, int childrenCount)
        {
            this.isMarried = isMarried;
            if (isMarried)
            {
                this.childrenCount = childrenCount;
            }

            return this;
        }
        public PersonalInformationBuilder WithJobInfo(string job, int minimumIncome)
        {
            this.job = job;
            this.minimumIncom = minimumIncome;
            return this;
        }

        public PersonalInformationBuilder WithBirthDate(DateTime date)
        {
            this.birthDate = date;
            return this;
        }

        public PersonalInformation Build()
        {
            //    string firstName, string lastName,  string motherFullName, string fatherFullName, DateTime birthDate, 
            //string identityNumber, string job, bool isMale, bool isMarried, int childrenCount, int minimumIncome
            return new PersonalInformation(firstName, lastName, motherFullName, fatherFullName, birthDate, identityNumber, job, isMale, isMarried, childrenCount, minimumIncom);
        }
    }

}