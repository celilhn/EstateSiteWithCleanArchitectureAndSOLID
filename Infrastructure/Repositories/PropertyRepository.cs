using System.Collections.Generic;
using System.Linq;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using static Domain.Constants.Constants;

namespace Infrastructure.Repositories
{
    public class PropertyRepository: IPropertyRepository
    {
        private readonly CacheManagerDbContext context;
        public PropertyRepository(CacheManagerDbContext context)
        {
            this.context = context;
        }

        public Property AddProperty(Property property)
        {
            context.Properties.Add(property);
            context.SaveChanges();
            return property;
        }

        public Property UpdateProperty(Property property)
        {
            context.Entry(property).State = EntityState.Modified;
            context.SaveChanges();
            return property;
        }

        public Property GetProperty(int Id)
        {
            return context.Properties.SingleOrDefault(x => x.Id == Id);
        }

        public List<Property> GetProperties()
        {
            return context.Properties.Where(x => x.Status == StatusCodes.Active).ToList();
        }

        public List<Property> GetProperties(int memberId)
        {
            return context.Properties.Where(x => x.Status == StatusCodes.Active && x.MemberId == memberId).ToList();
        }
    }
}
