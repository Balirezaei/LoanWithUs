namespace LoanWithUs.Domain
{
    public class Administrator
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }

        public Administrator(string firstName, string lastName, string mobileNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            MobileNumber = mobileNumber;
        }
    }
}