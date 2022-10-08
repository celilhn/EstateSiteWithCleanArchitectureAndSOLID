using System;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository tagRepository;
        public TagService(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }

        public Tag SaveTag(Tag tag)
        {
            if (tag.Id > 0)
            {
                tag.UpdateDate = DateTime.Now;
                tagRepository.UpdateTag(tag);
            }
            else
            {
                tagRepository.AddTag(tag);
            }
            return tag;
        }

        public Tag GetTag(int Id)
        {
            return this.tagRepository.GetTag(Id);
        }
    }
}
