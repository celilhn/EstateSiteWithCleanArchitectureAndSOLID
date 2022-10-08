

namespace Application.Models
{
    public class EmailModel
    {
        public string From { get; set; }
        public string FromName { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsBodyHtml { get; set; }
        public string Password { get; set; }
        public string SmtpClient { get; set; }
        public int Port { get; set; }
        public bool Ssl { get; set; }
        public string Username { get; set; }
    }
}
