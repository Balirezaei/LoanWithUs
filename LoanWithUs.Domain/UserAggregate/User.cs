namespace LoanWithUs.Domain.UserAggregate
{
    public class User
    {
        public int Id { get; protected set; }
        public IdentityInformation IdentityInformation { get; protected set; }
        public EducationalInformation EducationalInformation { get; protected set; }
        public UserConfirmation UserConfirmation { get; protected set; }
        public AddressInformation AddressInformation { get; protected set; }
        public PersonalInformation PersonalInformation { get; protected set; }
        public List<UserDocument> UserDocuments { get; protected set; }
        public bool HasCertificate { get { return UserConfirmation.TotalConfirmation; } }
        public List<UserLogin> UserLogins { get; protected set; } 
      

    }
}