using System.Collections.Generic;
using Domain.Models;
using static Domain.Constants.Constants;

namespace Domain.Interfaces
{
    public interface IImageRepository
    {
        Image AddImage(Image image);
        Image UpdateImage(Image image);
        Image GetImage(int Id);
        Image GetImage(int memberId, ImageTypes type);
        List<Image> GetMemberImages(int Id);
    }
}
