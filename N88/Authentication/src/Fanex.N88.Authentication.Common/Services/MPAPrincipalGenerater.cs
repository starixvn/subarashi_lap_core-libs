using Fanex.N88.Authentication.Common.Models;
using System.Security.Claims;
using System.Security.Principal;

namespace Fanex.N88.Authentication.Common.Services
{
    public class MPAPrincipalGenerater : IMPAPrincipalGenerater
    {
        public ClaimsPrincipal Generate(AuthInfo authInfo, string authenticationType)
        {
            var identityClaim = new Claim(ClaimTypes.Name, authInfo.UserAuthInfo.UserName);
            var licenseeClaim = new Claim(ClaimTypes.NameIdentifier, authInfo.LicenseeAuthInfo.LicenseeName);
            var claims = new ClaimsIdentity(new[] { identityClaim, licenseeClaim }, authenticationType);
            var principal = new GenericPrincipal(claims, new string[] { });

            return principal;
        }
    }
}