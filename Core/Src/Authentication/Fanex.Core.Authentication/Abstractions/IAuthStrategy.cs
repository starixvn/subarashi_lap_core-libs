using System.Threading.Tasks;

namespace Fanex.Core.Authentication
{
    public interface IAuthStrategy<T>
        where T : class
    {
        Task<T> AuthenticateAsync(string token);

        T Authenticate(string token);
    }
}