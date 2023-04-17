namespace LoanWithUs.Domain
{
    public class UserDocument
    {
        protected UserDocument() { }
        public DocumentType DocumentType { get; set; }
        public LoanWithUsFile File { get; set; }

    }
}