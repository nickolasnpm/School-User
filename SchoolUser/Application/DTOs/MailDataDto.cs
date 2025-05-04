namespace SchoolUser.Application.DTOs
{
    public class MailDataDto
    {
        public required string EmailToId { get; set; }
        public required string EmailToName { get; set; }
        public string? EmailCcId { get; set; }
        public string? EmailCcName { get; set; }
        public required string EmailSubject { get; set; }
        public required string EmailBody { get; set; }
    }
}