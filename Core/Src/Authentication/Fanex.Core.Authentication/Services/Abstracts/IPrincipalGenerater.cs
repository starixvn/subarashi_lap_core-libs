using Fanex.Core.Authentication.Abstractions;
using System.Security.Claims;

namespace Fanex.Core.Authentication
{
    public interface IPrincipalGenerater<in T>
       where T : IAuthInfo
    {
        ClaimsPrincipal Generate(T authInfo, string authType);
    }
}