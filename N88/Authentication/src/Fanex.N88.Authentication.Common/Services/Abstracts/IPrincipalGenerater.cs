using Fanex.N88.Authentication.Common.Models;
using System.Security.Claims;

namespace Fanex.N88.Authentication.Common.Services
{
    public interface IPrincipalGenerater<in T>
       where T : class
    {
        ClaimsPrincipal Generate(T authInfo, string authenticationType);
    }

    public interface IMPAPrincipalGenerater : IPrincipalGenerater<AuthInfo>
    {
        ClaimsPrincipal Generate(AuthInfo authInfo, string authenticationType);
    }
}