using Fanex.N88.Authentication.Common.Models;
using Fanex.N88.Authentication.Extensions.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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

        private AuthenticationTicket CreateTicket(AuthInfo authInfo)
        {
            var principal = Options.PrincipalGenerater.Generate(authInfo, Scheme.Name);
            return new AuthenticationTicket(principal, Scheme.Name);
        }

        private void ShareIdentityData(AuthInfo authInfo)
        {
            Context.Items.Add(AuthenticationSchema.MPASharedAuth, authInfo);
        }
    }
}