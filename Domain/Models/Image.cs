using Domain.Common;
using static Domain.Constants.Constants;

namespace Domain.Models
{
    public class Image : ExtendedBaseModel
    {
        public string Url { get; set; }
        public ImageTypes Type { get; set; }
        public int? MemberId { get; set; }
        public int? PropertyId { get; set; }
        public int? NewsId { get; set; }
        public virtual Member? Member { get; set; }
        public virtual Property? Property { get; set; }
        public virtual News? News { get; set; }
    }
}
