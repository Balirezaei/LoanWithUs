using LoanWithUs.Common;
using LoanWithUs.Common.ExtentionMethod;

namespace LoanWithUs.ApplicationService.Contract
{
    public class FileDto
    {
        public long Id { get; set; }
        public string FileUrl { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
        public FileType FileType { get; set; }
        public string FileTypeDescription
        {
            get { return this.FileType.GetDisplayName(); }
        }
    }
}