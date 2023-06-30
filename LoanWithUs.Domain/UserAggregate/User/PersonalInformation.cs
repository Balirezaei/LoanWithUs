namespace LoanWithUs.Domain
{
    public class PersonalInformation
    {
        protected PersonalInformation() { }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string MotherFullName { get; private set; }
        public string FatherFullName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string IdentityNumber { get; private set; }
        public string Job { get; private set; }
        public bool IsMale { get; private set; }
        public bool IsMarried { get; private set; }
        public int ChildrenCount { get; private set; }
        public int MinimumIncome { get; set; }
        internal PersonalInformation(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public PersonalInformation(string firstName, string lastName,  string motherFullName, string fatherFullName, DateTime birthDate, 
            string identityNumber, string job, bool isMale, bool isMarried, int childrenCount, int minimumIncome)
        {
            FirstName = firstName;
            LastName = lastName;
            MotherFullName = motherFullName;
            FatherFullName = fatherFullName;
            BirthDate = birthDate;
            IdentityNumber = identityNumber;
            Job = job;
            IsMale = isMale;
            IsMarried = isMarried;
            ChildrenCount = childrenCount;
            MinimumIncome = minimumIncome;
        }
    }

}