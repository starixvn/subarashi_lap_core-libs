using Fanex.Core.Authentication.Abstractions;
using System.Threading.Tasks;

namespace Fanex.Core.Authentication
{
    public interface IAuthStrategy<T>
        where T : IAuthInfo
    {
        Task<T> AuthenticateAsync(string token);

        T Authenticate(string token);
    }
}