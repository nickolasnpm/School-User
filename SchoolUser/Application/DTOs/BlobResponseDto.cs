namespace SchoolUser.Application.DTOs
{
    public class BlobResponseDto
    {
        public BlobResponseDto()
        {
            blobDto = new BlobDto();
        }

        public string? Status { get; set; }
        public bool Error { get; set; }
        public BlobDto blobDto { get; set; }
    }
}