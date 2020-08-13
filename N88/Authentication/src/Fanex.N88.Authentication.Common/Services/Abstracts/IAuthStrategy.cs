using System.Threading.Tasks;

namespace Fanex.N88.Authentication.Common.Services
{
    public interface IAuthStrategy<T>
    {
        Task<T> AuthenticateAsync(string token);
    }
}