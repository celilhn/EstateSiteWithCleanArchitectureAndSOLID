using Domain.Common;

namespace Domain.Models
{
    public class Tag : ExtendedBaseModel
    {
        public string Text { get; set; }
        public int? NewsID { get; set; }
        public int? PropertyID { get; set; }
        public virtual News? News { get; set; }
        public virtual Property? Property { get; set; }

    }
}
