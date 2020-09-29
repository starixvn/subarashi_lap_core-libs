using System.Security.Claims;

namespace Fanex.Core.Authentication
{
    public interface IPrincipalGenerater<in T>
       where T : class
    {
        ClaimsPrincipal Generate(T authInfo, string authType);
    }
}