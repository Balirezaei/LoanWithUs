namespace LoanWithUs.Domain.UserAggregate
{
    public class UserDocument
    {
        protected UserDocument() { }
        public DocumentType DocumentType { get; set; }
        public LoanWithUsFile File { get; set; }

    }
}