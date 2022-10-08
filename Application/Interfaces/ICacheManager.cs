
namespace Application.Interfaces
{
    public interface ICacheManager
    {
        T Set<T>(object key, T value, int expirationInMinutes = 60);
        bool Contains(object key);
        T Get<T>(object key);
        void Clear(object key);
        void Reset();
    }
}
