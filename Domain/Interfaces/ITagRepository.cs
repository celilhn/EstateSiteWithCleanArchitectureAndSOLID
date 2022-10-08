using Domain.Models;

namespace Domain.Interfaces
{
    public interface ITagRepository
    {
        Tag AddTag(Tag tag);
        Tag UpdateTag(Tag tag);
        Tag GetTag(int Id);
    }
}
