using Domain.Common;

namespace Domain.Models
{
    public class MemberShipPlan : ExtendedBaseModel
    {
        public string Name { get; set; }
        public string IconUrl { get; set; }
        public int Price { get; set; }
        public int ListCount { get; set; }
        public int FeaturedListCount { get; set; }
    }
}
