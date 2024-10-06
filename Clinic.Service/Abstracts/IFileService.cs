using Microsoft.AspNetCore.Http;

namespace Clinic.Service.Abstracts
{
    public interface IFileService
    {
        public Task<string> UploadImage(string Location, IFormFile file);
    }
}
