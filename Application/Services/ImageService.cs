using System;
using System.Collections.Generic;
using System.IO;
using Application.Interfaces;
using Domain.Constants;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using static Domain.Constants.Constants;

namespace Application.Services
{
    public class ImageService: IImageService
    {
        private readonly IImageRepository imageRepository;
        public ImageService(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        public Image SaveImage(Image image)
        {
            if (image.Id > 0)
            {
                image.UpdateDate = DateTime.Now;
                imageRepository.UpdateImage(image);
            }
            else
            {
                imageRepository.AddImage(image);
            }
            return image;
        }

        public Image GetImage(int Id)
        {
            return imageRepository.GetImage(Id);
        }

        public Image GetImage(int memberId, ImageTypes type)
        {
            return imageRepository.GetImage(memberId, type);
        }

        public List<Image> GetMemberImages(int Id)
        {
           return imageRepository.GetMemberImages(Id);
        }

        public string UploadImage(IFormFile file, string authorsFile)
        {

            string result = "";
            if (file != null)
            {
                if (authorsFile != null)
                {
                    if (File.Exists(Path.Combine("wwwroot\\assets\\images", authorsFile)))
                    {
                        File.Delete(Path.Combine("wwwroot\\assets\\images", authorsFile));
                    }
                }
                var extent = Path.GetExtension(file.FileName);
                var randomName = ($"{Guid.NewGuid()}{extent}");
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\assets\\images", randomName);
                var stream = new FileStream(path, FileMode.Create);
                file.CopyToAsync(stream);
                result = randomName;
            }
            return result;
        }
    }
}
