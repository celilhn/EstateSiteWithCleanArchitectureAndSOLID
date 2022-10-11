using System.Collections.Generic;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using static Domain.Constants.Constants;

namespace Application.Interfaces
{
    public interface IImageService
    {
        Image SaveImage(Image image);
        Image GetImage(int Id);
        Image GetImage(int memberId, ImageTypes type);
        List<Image> GetMemberImages(int Id);
        string UploadImage(IFormFile file, string authorsFile);
    }
}
