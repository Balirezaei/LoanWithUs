using LoanWithUs.Common;
using Microsoft.AspNetCore.Http;

namespace LoanWithUs.FileService
{
    public class HardDiskFileService : IFileService
    {
        public Task<byte[]> ReadFileBytes(string path)
        {
            return System.IO.File.ReadAllBytesAsync(path);
        }

        public void RemoveFile(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }

        public async Task WriteFile(IFormFile file ,string path)
        {
            using (var stream = File.Create(path))
            {
                await file.CopyToAsync(stream);
            }
        }
    }
}