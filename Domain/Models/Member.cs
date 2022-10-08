using System.Collections.Generic;
using Domain.Common;

namespace Domain.Models
{
    public class Member : ExtendedBaseModel
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Email { get; set; }
        public int SellingPercent { get; set; }
        public int BuyingPercent { get; set; }

        public virtual List<Image> Images { get; set; }
        public virtual List<Property> Properties { get; set; }
    }
}
