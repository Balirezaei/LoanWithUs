namespace LoanWithUs.Domain
{
    public class UserDocument
    {
        protected UserDocument() { }

        internal UserDocument(LoanWithUsFile file)
        {
            File = file;
        }

        public LoanWithUsFile File { get; set; }

    }
}