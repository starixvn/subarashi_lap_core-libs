using Fanex.N88.Authentication.Common.Models;
using System;
using System.Threading.Tasks;

namespace Fanex.N88.Authentication.Common.Services
{
    public class MPAAuthSharedSessionStrategy : IMPAAuthStrategy
    {
        private readonly MPASharedSessionOption _options;
        private readonly IRedisClient _redisClient;

        public MPAAuthSharedSessionStrategy(MPASharedSessionOption options, IRedisClient redisClient)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _redisClient = redisClient ?? throw new ArgumentNullException(nameof(redisClient));
        }

        public AuthInfo Authenticate(string token)
        {
            var key = BuildKey(token);
            var result = _redisClient.GetFromAssemblies<AuthInfo>(key);
            return result;
        }

        public async Task<AuthInfo> AuthenticateAsync(string token)
        {
            var key = BuildKey(token);
            var result = await _redisClient.GetFromAssembliesAsync<AuthInfo>(key).ConfigureAwait(false);
            return result;
        }

        private string BuildKey(string token)
        {
            return "{" + _options.PrefixKey + "_" + token + "}_Data";
        }
    }
}