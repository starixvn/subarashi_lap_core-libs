using Fanex.N88.Authentication.Common.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Linq;

namespace Fanex.N88.Authentication.Extensions.Models
{
    public class MPAAuthenticationOptions : AuthenticationSchemeOptions
    {
        private const string SharedAuthHeaderKey = "X-Shared-Auth-Key";

        public IMPAAuthStrategy AuthStrategy { get; set; }

        public Func<HttpRequest, string> TokenRetrieval { get; set; } = AccessTokenFromDefault;

        public override void Validate()
        {
            base.Validate();

            if (AuthStrategy is null)
            {
                throw new Exception($"{nameof(AuthStrategy)} is required");
            }

            if (TokenRetrieval == null)
            {
                throw new Exception($"{nameof(TokenRetrieval)} is required");
            }
        }

        private static Func<HttpRequest, string> AccessTokenFromDefault { get; set; } = request =>
        {
            string token;
            if (request.Query.TryGetValue(SharedAuthHeaderKey, out StringValues queryToken))
            {
                token = queryToken.FirstOrDefault();
            }
            else if (request.Headers.TryGetValue(SharedAuthHeaderKey, out StringValues headerToken))
            {
                token = headerToken.FirstOrDefault();
            }
            else
            {
                token = null;
            }

            return token;
        };
    }
}