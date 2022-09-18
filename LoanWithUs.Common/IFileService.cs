using Microsoft.AspNetCore.Http;

namespace LoanWithUs.Common
{
    public interface IFileService {

        Task WriteFile(IFormFile file, string path);
        void RemoveFile(string path);
        Task<byte[]> ReadFileBytes(string path);
    }
     
}