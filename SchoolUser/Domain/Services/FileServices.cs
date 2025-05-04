using Azure;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using MediatR;
using SchoolUser.Application.Constants.Interfaces;
using SchoolUser.Application.DTOs;
using SchoolUser.Application.ErrorHandlings;
using SchoolUser.Application.Mediator.UserMediator.Commands;
using SchoolUser.Application.Mediator.UserMediator.Queries;
using SchoolUser.Domain.Interfaces.Services;

namespace SchoolUser.Domain.Services
{
    public class FileServices : IFileServices
    {
        private readonly ISender _sender;
        private readonly IConfiguration _configuration;
        private readonly string _storageAccount = "";
        private readonly string _accessKey = "";
        private readonly string _blobUri = "";
        private readonly string _fileContainerName = "";
        private readonly StorageSharedKeyCredential _storageSharedKeyCredential;
        private readonly BlobContainerClient _blobContainerClient;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IReturnValueConstants _returnValueConstants;
        private readonly string _entityName = "User";

        public FileServices(ISender sender, IConfiguration configuration, IReturnValueConstants returnValueConstants)
        {
            _sender = sender;
            _configuration = configuration;
            _storageAccount = _configuration.GetValue<string>("BlobStorage:AccountName")!;
            _accessKey = _configuration.GetValue<string>("BlobStorage:AccountKey")!;
            _fileContainerName = _configuration.GetValue<string>("BlobStorage:ProfilePicturesContainer")!;
            _storageSharedKeyCredential = new StorageSharedKeyCredential(_storageAccount, _accessKey);
            _blobUri = $"https://{_storageAccount}.blob.core.windows.net";
            _blobServiceClient = new BlobServiceClient(new Uri(_blobUri), _storageSharedKeyCredential);
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(_fileContainerName);
            _returnValueConstants = returnValueConstants;
        }

        public async Task<BlobResponseDto> UploadAsync(IFormFile formFile, string tokenHeader)
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
            var fileName = $"{date}_{formFile.FileName}";

            BlobResponseDto response = new BlobResponseDto();
            BlobClient client = _blobContainerClient.GetBlobClient(fileName);

            string? cleanedToken = tokenHeader!.Replace("Bearer ", "");
            var user = await _sender.Send(new GetUserByJwtTokenQuery(cleanedToken));

            if (user == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, _entityName));
            }

            await using (Stream? data = formFile.OpenReadStream())
            {
                await client.UploadAsync(data);
            }

            var updatedUser = await _sender.Send(new UpdateProfilePictureUriCommand(user!.Id, client.Uri.AbsoluteUri));

            if (updatedUser == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, _entityName));
            }

            response.Status = $"File {fileName} uploaded successfully";
            response.Error = false;
            response.blobDto.Name = client.Name;
            response.blobDto.ContentUri = client.Uri.AbsoluteUri;
            response.blobDto.ContentType = formFile.ContentType;

            return response;
        }

        public async Task<BlobDto?> DownloadAsync(string fileName)
        {
            BlobClient client = _blobContainerClient.GetBlobClient(fileName);

            if (await client.ExistsAsync())
            {
                Stream blobContent = await client.OpenReadAsync();
                Response<BlobDownloadResult> downloadResult = await client.DownloadContentAsync();

                return new BlobDto
                {
                    Name = fileName,
                    ContentUri = client.Uri.AbsoluteUri,
                    ContentType = downloadResult.Value.Details.ContentType,
                    Content = blobContent
                };
            }

            return null;
        }

        private async Task<bool> DeleteAsync(string fileName)
        {
            BlobClient client = _blobContainerClient.GetBlobClient(fileName);

            try
            {
                await client.DeleteAsync();
                return true;
            }
            catch (RequestFailedException)
            {
                return false;
            }
        }

    }
}