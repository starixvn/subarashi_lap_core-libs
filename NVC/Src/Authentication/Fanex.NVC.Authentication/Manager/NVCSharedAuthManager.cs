using Fanex.Core.Authentication.Abstractions;
using Fanex.Core.Authentication.Models;
using Fanex.Core.Authentication.Services;
using Fanex.Core.Utils;
using Fanex.NVC.Authentication.Services;
using System;

namespace Fanex.NVC.Authentication
{
    public class NVCSharedAuthManager
    {
        private static AuthSharedSessionOption AuthOptions;
        private static readonly Lazy<INVCAuthStrategy> LazyStrategy = new Lazy<INVCAuthStrategy>(() => new NVCAuthSharedSessionStrategy(AuthOptions, RedisClient));
        private static readonly Lazy<ISessionClient> LazyRedisClient = new Lazy<ISessionClient>(() => new RedisSessionClient(AuthOptions.Redis, new BinarySerializer()));
        private static ISessionClient RedisClient => LazyRedisClient.Value;

        public static NVCSharedAuthManager UseOptions(AuthSharedSessionOption authOptions = null)
        {
            AuthOptions = authOptions ?? new AuthSharedSessionOption();
            return new NVCSharedAuthManager();
        }

        public NVCSharedAuthManager UseRedis(string host, int port, string password, int database)
        {
            _ = AuthOptions ?? throw new NullReferenceException($"{nameof(AuthOptions)} has not been initialized");
            AuthOptions.Redis = new AuthRedisOption
            {
                Host = host,
                Port = port,
                Password = password,
                Database = database
            };
            return this;
        }

        public NVCSharedAuthManager UsePrefixKey(string prefixKey)
        {
            _ = AuthOptions ?? throw new NullReferenceException($"{nameof(AuthOptions)} has not been initialized");
            AuthOptions.PrefixKey = prefixKey;
            return this;
        }

        public static INVCAuthStrategy NVCAuthStrategy => LazyStrategy.Value;

        public static readonly INVCPrincipalGenerater NVCPrincipalGenerater = new NVCPrincipalGenerater();
    }
}