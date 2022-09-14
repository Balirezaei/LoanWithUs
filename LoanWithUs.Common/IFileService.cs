namespace LoanWithUs.Common
{
    public interface IFileService {

        Task WriteFile();
        void RemoveFile(string path);
        Task<byte[]> ReadFileBytes(string path);
    }
}