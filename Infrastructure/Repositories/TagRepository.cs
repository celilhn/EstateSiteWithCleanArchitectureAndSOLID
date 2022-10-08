using System.Linq;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly CacheManagerDbContext context;
        public TagRepository(CacheManagerDbContext context)
        {
            this.context = context;
        }

        public Tag AddTag(Tag tag)
        {
            context.Tags.Add(tag);
            context.SaveChanges();
            return tag;
        }

        public Tag UpdateTag(Tag tag)
        {
            context.Entry(tag).State = EntityState.Modified;
            context.SaveChanges();
            return tag;
        }

        public Tag GetTag(int Id)
        {
            return context.Tags.SingleOrDefault(x => x.Id == Id);
        }
    }
}
