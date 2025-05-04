namespace SchoolUser.Application.DTOs
{
    public class BlobDto
    {
        public string? Name { get; set; }
        public string? ContentUri { get; set; }
        public string? ContentType { get; set; }
        public Stream? Content { get; set; }
    }
}