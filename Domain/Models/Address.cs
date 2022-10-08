using Domain.Common;

namespace Domain.Models
{
    public class Address : ExtendedBaseModel
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
