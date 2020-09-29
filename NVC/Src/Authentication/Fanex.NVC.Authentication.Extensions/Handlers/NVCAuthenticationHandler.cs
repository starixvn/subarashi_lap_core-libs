using Fanex.NVC.Authentication.Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Fanex.NVC.Authentication.Extensions
{
    public class NVCAuthenticationHandler : AuthenticationHandler<NVCAuthenticationOptions>
    {
        public NVCAuthenticationHandler(IOptionsMonitor<NVCAuthenticationOptions> options,
            ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var token = Options.TokenRetrieval.Invoke(Request);
            if (!string.IsNullOrEmpty(token))
            {
                var authInfo = await Options.AuthStrategy.AuthenticateAsync(token);
                if (authInfo != null)
                {
                    ShareIdentityData(authInfo);
                    var ticket = CreateTicket(authInfo);

                    return AuthenticateResult.Success(ticket);
                }
            }
            return AuthenticateResult.NoResult();
        }

        private AuthenticationTicket CreateTicket(NVCAuthInfo authInfo)
        {
            var principal = Options.PrincipalGenerater.Generate(authInfo, Scheme.Name);
            return new AuthenticationTicket(principal, Scheme.Name);
        }

        private void ShareIdentityData(NVCAuthInfo authInfo)
        {
            Context.Items.Add(NVCAuthSchema.NVCSharedAuth, authInfo);
        }
    }
}