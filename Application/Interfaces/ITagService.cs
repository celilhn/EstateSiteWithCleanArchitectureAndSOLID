using System.Collections.Generic;
using Domain.Models;

namespace Application.Interfaces
{
    public interface ITagService
    {
        Tag AddTag(Tag tag);
        Tag UpdateTag(Tag tag);
        Tag GetTag(int Id);
        List<Tag> GetTags();
    }
}
