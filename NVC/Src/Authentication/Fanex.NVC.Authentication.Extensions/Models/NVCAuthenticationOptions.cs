using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Linq;

namespace Fanex.NVC.Authentication.Extensions
{
    public class NVCAuthenticationOptions : AuthenticationSchemeOptions
    {
        private const string DefaultTokenKey = "X-Shared-Auth-Key";

        public INVCAuthStrategy AuthStrategy { get; set; }

        public INVCPrincipalGenerater PrincipalGenerater { get; set; }

        public Func<HttpRequest, string> TokenRetrieval { get; set; } = AccessTokenFromDefault;

        public override void Validate()
        {
            base.Validate();

            if (AuthStrategy is null)
            {
                throw new Exception($"{nameof(AuthStrategy)} is required");
            }

            if (PrincipalGenerater is null)
            {
                throw new Exception($"{nameof(PrincipalGenerater)} is required");
            }

            if (TokenRetrieval == null)
            {
                throw new Exception($"{nameof(TokenRetrieval)} is required");
            }
        }

        private static readonly Func<HttpRequest, string> AccessTokenFromDefault = request =>
        {
            if (request.Headers.TryGetValue(DefaultTokenKey, out StringValues headerToken))
            {
                return headerToken.FirstOrDefault();
            }

            if (request.Query.TryGetValue(DefaultTokenKey, out StringValues queryToken))
            {
                return queryToken.FirstOrDefault();
            }

            return null;
        };
    }
}