
namespace Application.Models
{
    public class SmtpServer
    {
        public string SenderEmailAddress { get; set; }
        public int Port { get; set; }
        public bool UseSSL { get; set; }
        public string Url { get; set; }
        public bool RequiresLogin { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
