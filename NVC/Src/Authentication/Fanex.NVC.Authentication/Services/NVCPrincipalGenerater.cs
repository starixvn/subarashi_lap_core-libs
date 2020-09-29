using Fanex.NVC.Authentication.Infrastructure;
using System.Security.Claims;
using System.Security.Principal;

namespace Fanex.NVC.Authentication
{
    public class NVCPrincipalGenerater : INVCPrincipalGenerater
    {
        public virtual ClaimsPrincipal Generate(NVCAuthInfo authInfo, string authType)
        {
            var identityClaim = new Claim(ClaimTypes.Name, $"{authInfo.UserAuthInfo.UserId}_{authInfo.UserAuthInfo.UserName}");
            var licenseeClaim = new Claim(ClaimTypes.NameIdentifier, $"{authInfo.LicenseeAuthInfo.LicenseeId}_{authInfo.LicenseeAuthInfo.LicenseeName}");
            var claims = new ClaimsIdentity(new[] { identityClaim, licenseeClaim }, authType);
            var principal = new GenericPrincipal(claims, new string[] { });

            return principal;
        }
    }
}