using SchoolUser.Application.DTOs;

namespace SchoolUser.Domain.Interfaces.Services
{
    public interface IFileServices
    {
        Task<BlobResponseDto> UploadAsync(IFormFile formFile, string tokenHeader);
        Task<BlobDto?> DownloadAsync(string fileName);
    }
}