using System.Collections.Generic;
using System.Linq;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using static Domain.Constants.Constants;

namespace Infrastructure.Repositories
{
    public class ImageRepository: IImageRepository
    {
        private readonly CacheManagerDbContext context;
        public ImageRepository(CacheManagerDbContext context)
        {
            this.context = context;
        }

        public Image AddImage(Image image)
        {
            context.Images.Add(image);
            context.SaveChanges();
            return image;
        }

        public Image UpdateImage(Image image)
        {
            context.Entry(image).State = EntityState.Modified;
            context.SaveChanges();
            return image;
        }

        public Image GetImage(int Id)
        {
            return context.Images.SingleOrDefault(x => x.Id == Id);
        }

        public Image GetImage(int memberId, ImageTypes type)
        {
            return context.Images.SingleOrDefault(x =>
                x.MemberId == memberId && x.Status == StatusCodes.Active && x.Type == type);
        }

        public List<Image> GetMemberImages(int Id)
        {
            return context.Images.Where(x => x.MemberId == Id && x.Status == StatusCodes.Active).ToList();
        }
    }
}
