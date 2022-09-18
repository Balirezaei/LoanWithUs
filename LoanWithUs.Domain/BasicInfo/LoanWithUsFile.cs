using LoanWithUs.Common;

namespace LoanWithUs.Domain.BasicInfo
{
    public class LoanWithUsFile
    {
        public LoanWithUsFile(string path, string fileName, string extention, string fileUrl, FileType fileType)
        {
            Path = path;
            FileName = fileName;
            Extention = extention;
            FileUrl = fileUrl;
            FileType = fileType;
        }

        public int Id { get; private set; }
        public string Path { get; private set; }
        public string FileName { get; private set; }
        public string Extention { get; private set; }
        public string FileUrl { get; private set; }
        public FileType FileType { get; private set; }
    }
}