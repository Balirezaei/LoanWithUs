namespace LoanWithUs.ApplicationService.Contract
{
    public class CreateFileCommandResult
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
    }
}