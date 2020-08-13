using Fanex.N88.Authentication.Common.Models;
using Fanex.N88.Authentication.Extensions.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Security.Principal;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Fanex.N88.Authentication.Extensions.Handlers
{
    public class MPAAuthenticationHandler : AuthenticationHandler<MPAAuthenticationOptions>
    {
        public MPAAuthenticationHandler(IOptionsMonitor<MPAAuthenticationOptions> options,
            ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var token = Options.TokenRetrieval?.Invoke(Request);
            if (!string.IsNullOrEmpty(token))
            {
                var authInfo = await Options.AuthStrategy.AuthenticateAsync(token);
                if (authInfo != null)
                {
                    var ticket = CreateTicket(authInfo);
                    return AuthenticateResult.Success(ticket);
                }
            }

            return AuthenticateResult.NoResult();
        }

        private AuthenticationTicket CreateTicket(AuthInfo authInfo)
        {
            var identityClaim = new Claim(ClaimTypes.Name, authInfo.LicenseeAuthInfo.LicenseeId.ToString());
            var userDataClaim = new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(authInfo));
            var claims = new ClaimsIdentity(new[] { identityClaim, userDataClaim }, Scheme.Name);
            var principal = new GenericPrincipal(claims, new string[] { });

            return new AuthenticationTicket(principal, Scheme.Name);
        }
    }
}