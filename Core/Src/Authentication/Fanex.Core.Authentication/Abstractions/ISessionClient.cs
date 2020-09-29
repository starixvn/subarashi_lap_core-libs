using System.Threading.Tasks;

namespace Fanex.Core.Authentication
{
    public interface ISessionClient
    {
        Task<T> GetAsync<T>(string key);

        T Get<T>(string key);
    }
}