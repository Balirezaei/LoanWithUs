namespace LoanWithUs.Domain
{
    public class PersonalInformation
    {
        protected PersonalInformation() { }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string MatherFullName { get; private set; }
        public string FatherFullName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string IdentityNumber { get; private set; }
        public string Job { get; private set; }

        internal PersonalInformation(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}