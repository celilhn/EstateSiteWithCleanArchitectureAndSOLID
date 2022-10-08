using System.Collections.Generic;
using Domain.Common;
using static Domain.Constants.Constants;

namespace Domain.Models
{
    public class Property : ExtendedBaseModel
    {
        public short MemberId { get; set; }
        public string Title { get; set; }
        public string Adress { get; set; }
        public int BedroomCount { get; set; }
        public int BathRoomCount { get; set; }
        public int SqftSize { get; set; }
        public int StarCount { get; set; }
        public int VisibleCount { get; set; }
        public string Text { get; set; }
        public int BuildYear { get; set; }
        public int IsHaveFloorHeating { get; set; }
        public short IsHaveGlassWindows { get; set; }
        public short IsHaveFreeParking { get; set; }
        public short IsHaveMarbleFlooring { get; set; }
        public short IsHaveFurnished { get; set; }
        public short IsHaveBasement { get; set; }
        public short IsHaveAirConditioning { get; set; }
        public short IsHaveLawn { get; set; }
        public short IsHaveTVCable { get; set; }
        public short IsHaveBarbeque { get; set; }
        public short IsHaveMicrowave { get; set; }
        public short IsHaveWasher { get; set; }
        public short IsHaveDryer { get; set; }
        public short IsHaveRefrigerator { get; set; }
        public short IsHaveWiFi { get; set; }
        public short IsHaveGym { get; set; }
        public short IsHaveSauna { get; set; }
        public short IsHaveWindowCoverings { get; set; }
        public short IsHaveLaundry { get; set; }
        public short IsHaveSwimmingPool { get; set; }
        public string VideoUrl { get; set; }
        public string IFrameUrl { get; set; }
        public int Price { get; set; }
        public virtual Member Member { get; set; }
        public virtual List<Tag> Tags { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Image> Images { get; set; }
    }
}
