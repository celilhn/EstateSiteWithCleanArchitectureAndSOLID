using Domain.Models;

namespace Application.Interfaces
{
    public interface ITagService
    {
        Tag SaveTag(Tag tag);
        Tag GetTag(int Id);
    }
}
