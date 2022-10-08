using Domain.Common;

namespace Domain.Models
{
    public class Comment : ExtendedBaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public int? NewsId { get; set; }
        public int? PropertyId { get; set; }
        public virtual News? News { get; set; }
        public virtual Property? Property { get; set; }
    }
}
