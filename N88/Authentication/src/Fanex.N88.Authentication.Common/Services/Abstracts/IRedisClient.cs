using System.Threading.Tasks;

namespace Fanex.N88.Authentication.Common.Services
{
    public interface IRedisClient
    {
        Task<T> GetFromAssembliesAsync<T>(string key);
    }
}